using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      throw new NotImplementedException();
      return this.InsertedRecords;
    }

    protected void DoCreate()
    {
      this.IncrementInsertedRecords();
    }
  }
}
