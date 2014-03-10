using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public abstract class SkillTrackerDataGenerator : DataGenerator
  {
    private readonly UnitOfWork _unitOfWork;

    protected SkillTrackerDataGenerator(UnitOfWork unitOfWork)
    {
      this._unitOfWork = unitOfWork;
    }

    protected UnitOfWork UnitOfWork {
      get { return this._unitOfWork; }
    }
  }
}
