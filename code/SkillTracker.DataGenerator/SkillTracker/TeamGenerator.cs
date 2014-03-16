using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class TeamGenerator : SkillTrackerDataGenerator
  {
    public TeamGenerator(UnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Creates teams"; }
    }

    public override long Generate()
    {
      try
      {
        var department = this.UnitOfWork.DepartmentRepository.Get(d => d.Code == "PD").FirstOrDefault();
        if (department == null)
        {
          throw new Exception("Product department not found.");
        }

        this.DoCreate("SE".ToUpper(), "Sunstained Engeneering", "The main responsibility is to fix issues and release updates.", department.Id);
        this.DoCreate("TF".ToUpper(), "Task Force", "The main responsibility is to implement new features in the CMS product.", department.Id);
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected void DoCreate(string code, string teamName, string description, Guid departmentId)
    {
      var team = new Team();
      team.Id = Guid.NewGuid();
      team.Code = code;
      team.Name = teamName;
      team.DepartmentId = departmentId;
      team.Description = description;

      this.UnitOfWork.TeamRepository.Insert(team);
      this.IncrementInsertedRecords();
    }
  }
}
