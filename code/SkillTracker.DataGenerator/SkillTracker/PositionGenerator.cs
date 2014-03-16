using System;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class PositionGenerator : SkillTrackerDataGenerator
  {
    public PositionGenerator(UnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Generate supported positions"; }
    }

    public override long Generate()
    {
      try
      {
        this.DoCreate("DEV", "Developer", "The Developer");
        this.DoCreate("JDEV", "Junior Developer", "The Junior Developer");
        this.DoCreate("LDEV", "Lead Developer", "The Lead Developer");
        this.DoCreate("TL", "Team Leader", "The Lead of the team");
        this.DoCreate("PROJM", "Project Manager", "The Project Manager");
        this.DoCreate("QA", "Quality Assurance Specialist", "The quality assurance specialist");
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected virtual void DoCreate(string code, string name, string description)
    {
      var position = new Position();
      position.Id = Guid.NewGuid();
      position.Code = code;
      position.Name = name;
      position.Description = description;

      this.UnitOfWork.PositionRepository.Insert(position);
      this.IncrementInsertedRecords();
    }
  }
}
