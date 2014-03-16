using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class TeamPositionGenerator : SkillTrackerDataGenerator 
  {
    public TeamPositionGenerator(UnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Adds positions to teams"; }
    }

    public override long Generate()
    {
      try
      {
        this.DoCreate("SE", "DEV");
        this.DoCreate("SE", "QA");
        this.DoCreate("SE", "LDEV");
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected virtual void DoCreate(string teamCode, string positionCode)
    {
      var team = this.UnitOfWork.TeamRepository.Get(t => t.Code == teamCode.ToUpper()).FirstOrDefault();
      if (team == null)
      {
        throw  new Exception(string.Format("Team with code '{0}' not found.", teamCode));
      }

      var position = this.UnitOfWork.PositionRepository.Get(p => p.Code == positionCode.ToUpper()).FirstOrDefault();
      if (position == null)
      {
        throw new Exception(string.Format("Position with code '{0}' not found.", positionCode));
      }

      team.TeamPosition.Add(new TeamPosition(){Id = Guid.NewGuid(), PositionId = position.Id, TeamId = team.Id});
      this.UnitOfWork.TeamRepository.Update(team);
      this.IncrementInsertedRecords();
    }
  }
}
