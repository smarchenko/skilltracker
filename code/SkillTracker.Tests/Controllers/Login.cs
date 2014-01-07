using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillTracker.Web.Models;

namespace SkillTracker.Tests.Controllers
{
  [TestClass]
  public class Login
  {
    [TestMethod]
    public void IndexAction_ReturnView_Tester()
    {
      var controller = new LoginController();
      var result = controller.Index();

      Assert.IsTrue(result is ViewResult);
      Assert.AreEqual((result as ViewResult).ViewName, "Login");
    }
  }
}
