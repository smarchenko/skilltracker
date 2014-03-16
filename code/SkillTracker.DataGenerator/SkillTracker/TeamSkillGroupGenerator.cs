using System;
using System.Linq;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class TeamSkillGroupGenerator : SkillTrackerDataGenerator
  {
    public TeamSkillGroupGenerator(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Assigns a team to a Skill Group"; }
    }

    public override long Generate()
    {
      try
      {
        DoGenerate("SE", "Sitecore");
        DoGenerate("SE", "Development");
        DoGenerate("SE", "Architecture");
        DoGenerate("SE", "SE Tools and Libraries");
        DoGenerate("SE", "Processes");
        DoGenerate("SE", "Environment (Setup and Configuring)");
        DoGenerate("SE", "Management");
        DoGenerate("SE", "Manual Testing");
      }
      finally
      {
        UnitOfWork.Save();
      }

      return InsertedRecords;
    }

    protected virtual void DoGenerate(string teamCode , string skillGroupName)
    {
      var team = UnitOfWork.TeamRepository.Get(t => t.Code == teamCode.ToUpper()).FirstOrDefault();
      if (team == null)
      {
        throw new Exception(string.Format("Team with code '{0}' not found.", teamCode));
      }

      var sgroup =
        UnitOfWork.SkillGroupRepository.Get(sg => string.Compare(sg.Name, skillGroupName, StringComparison.InvariantCultureIgnoreCase) == 0)
                  .FirstOrDefault();
      if (sgroup == null)
      {
        throw new Exception(string.Format("Skill Group with name '{0}' not found.", skillGroupName));
      }

      sgroup.TeamSkillGroup.Add(new TeamSkillGroup { Id = Guid.NewGuid(), TeamId = team.Id, GroupId = sgroup.Id });
      UnitOfWork.SkillGroupRepository.Update(sgroup);
      IncrementInsertedRecords();
    }
  }
}
