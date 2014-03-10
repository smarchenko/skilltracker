using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NLog;
using SkillTracker.Web.Services.Logging;

namespace SkillTracker.Web.Models
{
	public class LoginController : Controller
	{
	  private ILogger logger;

	  protected ILogger Logger
	  {
	    get { return this.logger; }
	  }

	  public LoginController(ILogger logger)
	  {
      Contract.Requires<ArgumentNullException>(logger != null, "logger");
	    this.logger = logger;
	  }

	  // GET: /Login/
		[HttpGet]
    [AllowAnonymous]
    public ActionResult Index(string returnUrl)
		{
      ViewBag.ReturnUrl = returnUrl;
			return View("Login");
		}


    /// <summary>
    /// Logins the used specified by it's name and password.
    /// </summary>
		[HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Index(LoginModel model, string returnUrl)
		{
      Contract.Requires<ArgumentNullException>(model != null, "model");

      if (!model.Validate(new ValidationContext(model)).Any() && this.DoLogin(model))
      {
        this.Logger.Audit(string.Format("User with mail '{0}' entered the system.", model.UserMail));
        return RedirectToLocal(returnUrl);
      }

      // If we got this far, something failed, redisplay form
      ModelState.AddModelError("", "The user name or password provided is incorrect.");
      this.Logger.Audit(string.Format("User with mail '{0}' provided invalid credentials.", model.UserMail??"[UNKNOWN]"));
      ViewBag.ReturnUrl = returnUrl;
      return View("Login");
		}

    protected virtual ActionResult RedirectToLocal(string returnUrl)
    {
      if (IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }
    }

    /// <summary>
    /// Determines whether the specified URL is a local Url.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns></returns>
	  protected virtual bool IsLocalUrl(string url)
	  {
	    return Url.IsLocalUrl(url);
	  }

	  protected virtual bool DoLogin(LoginModel model)
	  {
      Contract.Requires<ArgumentNullException>(model != null, "model");

	    bool result = false;
	    try
	    {
	      var userName = Membership.GetUserNameByEmail(model.UserMail);
	      if (!string.IsNullOrEmpty(userName))
	      {
	        result = Membership.ValidateUser(userName, model.Password);
	        if (result)
	        {
	          FormsAuthentication.SetAuthCookie(userName, model.RememberMe);
	        }
	      }
	    }
	    catch (Exception ex)
	    {
        this.Logger.Error(string.Format("Cannot login user with email '{0}'.", model.UserMail ?? "[UNKNOWN]"), ex);
	    }

	    return result;
	  }
	}
}
