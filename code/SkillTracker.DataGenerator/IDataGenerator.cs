namespace SkillTracker.DataGenerator
{
  /// <summary>
  /// Interface for all data generator classes.
  /// </summary>
  public interface IDataGenerator
  {
    /// <summary>
    /// Gets the short description of the gfenerator. Might be shown in build script or console.
    /// </summary>
    /// <value>
    /// The short description.
    /// </value>
    string Description { get; }

    /// <summary>
    /// Generates the data and save into database.
    /// </summary>
    /// <returns>Number of created objects.</returns>
    long Generate();
  }
}
