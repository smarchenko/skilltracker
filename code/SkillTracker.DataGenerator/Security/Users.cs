using System.Web.Security;

namespace SkillTracker.DataGenerator.Security
{
  /// <summary>
  /// Generator of User objects.
  /// </summary>
  public class UsersGenerator : DataGenerator
  {
    /// <summary>
    /// Gets the short description of the gfenerator. Might be shown in build script or console.
    /// </summary>
    /// <value>
    /// The short description.
    /// </value>
    public override string Description {
      get { return "Creating ASP.NET membership users."; }
    }

    /// <summary>
    /// Generates this instance.
    /// </summary>
    /// <returns></returns>
    public override long Generate()
    {
      Create("smar", "b", "smar@sitecore.net");
      return InsertedRecords;
    }

    protected void Create(string name, string password, string email)
    {
      Membership.CreateUser(name, password, email);
      IncrementInsertedRecords();
    }
  }
}
