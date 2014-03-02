using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
      var controller = new TestLoginController { LocalUrl = false };
      var model = new TestLoginModel { Valid = false };
      var url = "/kuku";
      var result = controller.Login(model, url) as ViewResult;
      Assert.IsNotNull(result);
      Assert.AreEqual(url, result.ViewData["ReturnUrl"] as string, "Return Url should be kept");
    }

    [TestMethod]
    public void ModelErrorShouldBeReturnedForInvalidCredentials()
    {
      var controller = new TestLoginController {LocalUrl = false};
      var model = new TestLoginModel { Valid = false };
      var url = "/kuku";
      var result = controller.Login(model, url) as ViewResult;
      Assert.IsNotNull(result);
      Assert.IsFalse(result.ViewData.ModelState.IsValid);
    }

    [TestMethod]
    public void SuccessfulLoginShouldReturnToReturnUrl()
    {
      Assert.IsTrue(false, "test is not implemented.");
    }

    [TestMethod]
    public void LoginCodeShouldValidateUserEmail()
    {
      Assert.IsTrue(false, "test is not implemented.");
    }

    [TestMethod]
    public void LoginCodeShouldReturnErrorMessageForInvalidUser()
    {
      Assert.IsTrue(false, "test is not implemented.");
    }

    public class TestLoginController : LoginController
    {
      public bool? LocalUrl { get; set; }

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
