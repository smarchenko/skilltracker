using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace SkillTracker.Web.Infrastructure
{
  /// <summary>
  /// Ninject controller factory.
  /// </summary>
  public class NinjectControllerFactory : DefaultControllerFactory
  {
    /// <summary>
    /// The ninject kernel
    /// </summary>
    private IKernel ninjectKernel;

    /// <summary>
    /// Initializes a new instance of the <see cref="NinjectControllerFactory"/> class.
    /// </summary>
    public NinjectControllerFactory()
    {
      ninjectKernel = new StandardKernel();
      AddBindings();
    }

    /// <summary>
    /// Retrieves the controller instance for the specified request context and controller type.
    /// </summary>
    /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
    /// <param name="controllerType">The type of the controller.</param>
    /// <returns>
    /// The controller instance.
    /// </returns>
    protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    {
      if (controllerType == null)
      {
        return null;
      }

      return (IController) ninjectKernel.Get(controllerType);
    }

    /// <summary>
    /// Adds the IoC bindings.
    /// </summary>
    protected virtual void AddBindings()
    {

    }
  }
}