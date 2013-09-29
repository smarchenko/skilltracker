using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillTracker.Web;

namespace SkillTracker.Tests.Routes
{
  [TestClass]
  public class ReutesTester
  {
    [TestMethod]
    public void LoginRouteTest()
    {
    }

    protected bool TestIncomingRouteResult(RouteData routeResult, string controller, string action,
                                           object propertySet = null)
    {
      Func<object, object, bool> valCompare = (v1, v2) =>
        {
          return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
        };

      bool result = valCompare(routeResult.Values["controller"], controller) &&
                    valCompare(routeResult.Values["action"], action);

      if (propertySet != null)
      {
        PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
        foreach (var pi in propInfo)
        {
          if (
            !(routeResult.Values.ContainsKey(pi.Name) &&
              valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
          {
            result = false;
            break;
          }
        }
      }

      return result;
    }

    protected void TestRouteMatch(string url, string controller, string action, object routeProperties = null,
                                  string httpMethod = "GET")
    {
      RouteCollection routes = new RouteCollection();
      RouteConfig.RegisterRoutes(routes);

      RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

      Assert.IsNotNull(result);
      Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
    }

    protected HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
    {
      Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
      mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
      mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

      Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
      mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

      Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
      mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
      mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

      return mockContext.Object;
    }
  }
}
