using System;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class DepartmentGenerator : SkillTrackerDataGenerator
  {
    public DepartmentGenerator(UnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Creates available departments."; }
    }

    public override long Generate()
    {
      try
      {
        this.DoCreate("PD".ToUpper(), "Product Department", null);
      }
      finally
      {
        this.UnitOfWork.Save();
      }

      return this.InsertedRecords;
    }

    protected void DoCreate(string code, string name, string description)
    {
      var department = new Department {Code = code, Name = name, Description = description, Id = Guid.NewGuid()};
      this.UnitOfWork.DepartmentRepository.Insert(department);
      this.IncrementInsertedRecords();
    }
  }
}
