using System.Diagnostics.Contracts;

namespace SkillTracker.DataGenerator
{
  /// <summary>
  /// Base class for data generators.
  /// </summary>
  public abstract class DataGenerator : IDataGenerator
  {
    #region Interface members
    /// <summary>
    /// Gets the short description of the gfenerator. Might be shown in build script or console.
    /// </summary>
    /// <value>
    /// The short description.
    /// </value>
    public abstract string Description { get; }
    /// <summary>
    /// Generates the data and save into database.
    /// </summary>
    /// <returns>
    /// Number of created objects.
    /// </returns>
    public abstract long Generate();

    #endregion

    /// <summary>
    /// Stores number of inserted records.
    /// </summary>
    private long _insertedRecords;

    /// <summary>
    /// Gets the number of inserted records.
    /// </summary>
    /// <value>
    /// The number inserted records.
    /// </value>
    protected long InsertedRecords
    {
      get { return _insertedRecords; }
    }

    /// <summary>
    /// Increments the inserted records.
    /// </summary>
    protected void IncrementInsertedRecords()
    {
      IncrementInsertedRecords(1);
    }

    /// <summary>
    /// Increments the inserted records.
    /// </summary>
    /// <param name="number">The number of records to increment on.</param>
    protected void IncrementInsertedRecords(long number)
    {
      Contract.Requires(number > (long)(0));
      _insertedRecords += number;
    }
  }
}
