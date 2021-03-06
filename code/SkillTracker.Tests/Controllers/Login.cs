﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillTracker.Tests.Services;
using SkillTracker.Web.Models;
using SkillTracker.Web.Services.Logging;

namespace SkillTracker.Tests.Controllers
{
  [TestClass]
  public class Login
  {
    [TestMethod]
    public void IndexAction_ReturnView_Tester()
    {
      var controller = new LoginController(new FakeLogger());
      var result = controller.Index(null);

      Assert.IsTrue(result is ViewResult);
      Assert.AreEqual((result as ViewResult).ViewName, "Login");
    }

    [TestMethod]
    public void LoginModelValidation_RequiresEmail()
    {
      var model = new LoginModel
        {
          Password = "Some pwd",
          UserMail = ""
        };

      var result = new List<ValidationResult>(model.Validate(new ValidationContext(model)));
      Assert.IsTrue(result.Count > 0);
      Assert.IsTrue(result.Any(msg => System.String.Compare("User Email is required.", msg.ErrorMessage, System.StringComparison.OrdinalIgnoreCase) == 0), "email validation message not found.");
    }

    [TestMethod]
    public void LoginModelValidation_RequiresPassword()
    {
      var model = new LoginModel
      {
        Password = "",
        UserMail = "KUKU@KU.KU"
      };

      var result = new List<ValidationResult>(model.Validate(new ValidationContext(model)));
      Assert.IsTrue(result.Count == 1);
      Assert.IsTrue(result.Any(msg => System.String.Compare("User Password is required.", msg.ErrorMessage, System.StringComparison.OrdinalIgnoreCase) == 0), "password validation message not found.");
    }

    [TestMethod]
    public void LoginModelValidation_ValidateEmail()
    {
      var model = new LoginModel
      {
        Password = "Some pwd",
        UserMail = "non_valid_email"
      };

      var result = new List<ValidationResult>(model.Validate(new ValidationContext(model)));
      Assert.IsTrue(result.Count ==1);
      Assert.IsTrue(result.Any(msg => System.String.Compare("Email is not valid.", msg.ErrorMessage, System.StringComparison.OrdinalIgnoreCase) == 0), "email regex validation message not found.");
    }

    [TestMethod]
    public void KeepReturnUrlForInvalidCredentials()
    {
      var controller = new TestLoginController(new FakeLogger()) { LocalUrl = false };
      var model = new TestLoginModel { Valid = false };
      var url = "/kuku";
      var result = controller.Index(model, url) as ViewResult;
      Assert.IsNotNull(result);
      Assert.AreEqual(url, result.ViewData["ReturnUrl"] as string, "Return Url should be kept");
    }

    [TestMethod]
    public void ModelErrorShouldBeReturnedForInvalidCredentials()
    {
      var controller = new TestLoginController(new FakeLogger()) {LocalUrl = false};
      var model = new TestLoginModel { Valid = false };
      var url = "/kuku";
      var result = controller.Index(model, url) as ViewResult;
      Assert.IsNotNull(result);
      Assert.IsFalse(result.ViewData.ModelState.IsValid);
    }

    [TestMethod]
    public void SuccessfulLoginShouldReturnToReturnUrl()
    {
      var controller = new TestLoginController(new FakeLogger()) { LocalUrl = true, LoginResult = true};
      var model = new TestLoginModel { Valid = true };
      var url = "/kuku";
      var result = controller.Index(model, url) as RedirectResult;
      Assert.IsNotNull(result);
      Assert.AreEqual(url, result.Url, "return url");
    }

    public class TestLoginController : LoginController
    {
      public bool? LocalUrl { get; set; }

      public bool? LoginResult { get; set; }

      public TestLoginController(ILogger logger) : base(logger)
      {
      }

      protected override bool DoLogin(LoginModel model)
      {
        if (this.LoginResult == null)
        {
          return base.DoLogin(model);
        }

        return this.LoginResult == true;
      }

      protected override bool IsLocalUrl(string url)
      {
        if (this.LocalUrl == null)
        {
          base.IsLocalUrl(url);
        }

        return LocalUrl ?? false;
      }
    }

    public class TestLoginModel : LoginModel
    {
      public bool? Valid { get; set; }

      public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
        if (Valid == null)
        {
          return base.Validate(validationContext);
        }

        if (Valid == true)
        {
          return new List<ValidationResult>();
        }

        return new List<ValidationResult> {new ValidationResult("Some fake exception.")};
      }
    }
  }
}
