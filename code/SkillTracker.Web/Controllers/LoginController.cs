using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkillTracker.Web.Models
{
	public class LoginController : Controller
	{
		//        
		// GET: /Login/
		[HttpGet]
		public ActionResult Index()
		{
			return View("Login");
		}

		[HttpPost]
		public ActionResult Index(string usermail, string password)
		{
			return View("Login");
		}

	}
}
