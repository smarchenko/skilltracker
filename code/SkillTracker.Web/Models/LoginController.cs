﻿using System;
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

        public ActionResult Index()
        {
            return View("Login");
        }

    }
}
