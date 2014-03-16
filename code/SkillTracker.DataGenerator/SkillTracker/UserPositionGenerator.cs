using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class UserPositionGenerator : SkillTrackerDataGenerator
  {
    public UserPositionGenerator(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Assigns position to a user"; }
    }

    public override long Generate()
    {
      try
      {
        this.DoCreate("smar@sitecore.net", "LDEV");
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected virtual void DoCreate(string userMail, string positionCode)
    {
      var userName = Membership.GetUserNameByEmail(userMail);
      if(string.IsNullOrEmpty(userName))
      {
        throw new Exception(string.Format("User with email '{0}' not found.", userMail));
      }

      var user = Membership.GetUser(userName);
      if (user == null)
      {
        throw new Exception(string.Format("User with name '{0}' not found.", userName));
      }

      var position = this.UnitOfWork.PositionRepository.Get(p => p.Code == positionCode.ToUpper()).FirstOrDefault();
      if (position == null)
      {
        throw new Exception(string.Format("Position with code '{0}' not found.", positionCode));
      }

      position.UserPosition.Add(new UserPosition(){Id = Guid.NewGuid(), PositionId = position.Id, UserId = (Guid)user.ProviderUserKey});
      this.UnitOfWork.PositionRepository.Update(position);
      this.IncrementInsertedRecords();
    }
  }
}
