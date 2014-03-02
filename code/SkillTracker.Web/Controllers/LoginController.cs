using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillTracker.Web.Models
{
	public class LoginController : Controller
	{
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
    public ActionResult Login(LoginModel model, string returnUrl)
		{
      Contract.Requires<ArgumentNullException>(model != null, "model");

      if (!model.Validate(new ValidationContext(model)).Any())
      {
        return RedirectToLocal(returnUrl);
      }

      // If we got this far, something failed, redisplay form
      ModelState.AddModelError("", "The user name or password provided is incorrect.");
      ViewBag.ReturnUrl = returnUrl;
      return View(model);
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
	}
}
