using System;
using System.Linq;
using System.Web.Security;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class UserTeamGenerator : SkillTrackerDataGenerator
  {
    public UserTeamGenerator(UnitOfWork unit) : base(unit)
    {
    }

    public override string Description
    {
      get { return "Adds a user to a team"; }
    }

    public override long Generate()
    {
      try
      {
        this.DoCreate("smar@sitecore.net", "SE");
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected virtual void DoCreate(string userMail, string teamCode)
    {
      var userName = Membership.GetUserNameByEmail(userMail);
      if (string.IsNullOrEmpty(userName))
      {
        throw new Exception(string.Format("User with email '{0}' not found.", userMail));
      }

      var user = Membership.GetUser(userName);
      if (user == null)
      {
        throw new Exception(string.Format("User with name '{0}' not found.", userName));
      }

      var team = this.UnitOfWork.TeamRepository.Get(t => t.Code == teamCode.ToUpper()).FirstOrDefault();
      if (team == null)
      {
        throw new Exception(string.Format("Team with code '{0}' not found.", teamCode));
      }

      team.UserTeam.Add(new UserTeam(){Id = Guid.NewGuid(), TeamId = team.Id, UserId = (Guid)user.ProviderUserKey});
      this.UnitOfWork.TeamRepository.Update(team);
      this.IncrementInsertedRecords();
    }

  }
}
