using System;
using System.Linq;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class PositionSkillGroupGenerator : SkillTrackerDataGenerator
  {
    public PositionSkillGroupGenerator(UnitOfWork unit) : base(unit)
    {
    }

    public override string Description
    {
      get { return "Assigns skill group to a position"; }
    }

    public override long Generate()
    {
      try
      {
        DoGenerate("DEV", "Sitecore");
        DoGenerate("DEV", "Development");
        DoGenerate("DEV", "Architecture");
        DoGenerate("DEV", "SE Tools and Libraries");
        DoGenerate("DEV", "Processes");
        DoGenerate("DEV", "Environment (Setup and Configuring)");

        DoGenerate("JDEV", "Sitecore");
        DoGenerate("JDEV", "Development");
        DoGenerate("JDEV", "SE Tools and Libraries");
        DoGenerate("JDEV", "Processes");
        DoGenerate("JDEV", "Environment (Setup and Configuring)");

        DoGenerate("LDEV", "Sitecore");
        DoGenerate("LDEV", "Development");
        DoGenerate("LDEV", "Architecture");
        DoGenerate("LDEV", "SE Tools and Libraries");
        DoGenerate("LDEV", "Processes");
        DoGenerate("LDEV", "Environment (Setup and Configuring)");
        DoGenerate("LDEV", "Management");

        DoGenerate("TL", "Management");
        DoGenerate("PROJM", "Management");

        DoGenerate("QA", "Manual Testing");
        DoGenerate("QA", "Sitecore");
      }
      finally
      {
        UnitOfWork.Save();
      }

      return InsertedRecords;
    }

    protected virtual void DoGenerate(string positionCode, string skillGroupName)
    {
      var position = UnitOfWork.PositionRepository.Get(p => p.Code == positionCode.ToUpper()).FirstOrDefault();
      if (position == null)
      {
        throw new Exception(string.Format("Position with code '{0}' not found.", positionCode));
      }

      var sgroup =
        UnitOfWork.SkillGroupRepository.Get(sg => string.Compare(sg.Name, skillGroupName, StringComparison.InvariantCultureIgnoreCase) == 0)
                  .FirstOrDefault();
      if (sgroup == null)
      {
        throw new Exception(string.Format("Skill Group with name '{0}' not found.", skillGroupName));
      }

      sgroup.PositionSkillGroup.Add(new PositionSkillGroup{Id = Guid.NewGuid(), PositionId = position.Id, GroupId = sgroup.Id});
      UnitOfWork.SkillGroupRepository.Update(sgroup);
      IncrementInsertedRecords();
    }

  }
}
