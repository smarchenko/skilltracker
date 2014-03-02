using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SkillTracker.Web.Models
{
  /// <summary>
  /// Model that is used by Login page.
  /// </summary>
  public class LoginModel : IValidatableObject
  {
    [Required]
    [Display(Name = "User email")]
    [DataType(DataType.EmailAddress)]
    public string UserMail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }

    public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      var result = new List<ValidationResult>();
      if (string.IsNullOrEmpty(this.UserMail))
      {
        result.Add(new ValidationResult("User Email is required."));
      }

      string emailvalidation = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
      var re = new Regex(emailvalidation);
      if (!re.IsMatch(this.UserMail))
      {
        result.Add(new ValidationResult("Email is not valid."));
      }

      if (string.IsNullOrEmpty(this.Password))
      {
        result.Add(new ValidationResult("User Password is required."));
      }

      return result;
    }
  }
}