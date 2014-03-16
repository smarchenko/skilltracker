using System;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class SkillGroupGenerator : SkillTrackerDataGenerator
  {
    public SkillGroupGenerator(UnitOfWork unit) : base(unit)
    {
    }

    public override string Description
    {
      get { return "Generates Skill Groups"; }
    }

    public override long Generate()
    {
      try
      {
        this.DoCreate("Sitecore", "Sitecore CMS related skills.");
        this.DoCreate("Development", "Development related skills.");
        this.DoCreate("Architecture", "Skills in architecture area.");
        this.DoCreate("SE Tools and Libraries", "Skills in tools and libraries that are in use in SE team.");
        this.DoCreate("Processes", "Knowing the processed in use.");
        this.DoCreate("Environment (Setup and Configuring)", "Environment related knowledge.");
        this.DoCreate("Manual Testing", "Manual testing skills.");
        this.DoCreate("Management", "Management related skills.");
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected virtual void DoCreate(string name, string description)
    {
      var skillGroup = new SkillGroup {Id = Guid.NewGuid(), Name = name, Description = description};

      this.UnitOfWork.SkillGroupRepository.Insert(skillGroup);
      this.IncrementInsertedRecords();
    }
  }
}
