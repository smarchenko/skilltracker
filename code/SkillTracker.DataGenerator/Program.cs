using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using SkillTracker.DataGenerator.Security;

namespace SkillTracker.DataGenerator
{
  public class Program
  {
    static void Main(string[] args)
    {
      var generators = CreateGenerators(args);
      foreach (IDataGenerator generator in generators)
      {
        Contract.Assert(generator != null);
        var timer = new Stopwatch();
        Console.WriteLine("Start: {0}...", generator.Description);
        timer.Start();
        var recordsNumber = generator.Generate();
        timer.Stop();
        Console.WriteLine("Done: {0}ms. {1} records.", timer.ElapsedMilliseconds, recordsNumber);
      }
    }

    public static List<IDataGenerator> CreateGenerators(string[] args)
    {
      Contract.Ensures(Contract.Result<List<IDataGenerator>>() != null);

      var result = new List<IDataGenerator>();

      result.Add(new UsersGenerator());

      return result;
    }
  }
}
