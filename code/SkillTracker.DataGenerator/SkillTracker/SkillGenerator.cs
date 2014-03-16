using System;
using System.Linq;
using SkillTracker.Data;

namespace SkillTracker.DataGenerator
{
  public class SkillGenerator : SkillTrackerDataGenerator
  {
    public SkillGenerator(UnitOfWork unitOfWork)
      : base(unitOfWork)
    {
    }

    public override string Description
    {
      get { return "Generates Skill"; }
    }

    public override long Generate()
    {
      try
      {
        DoGenerate("Architecture (Layers, etc)", "Sitecore CMS architecture", "Sitecore");
        DoGenerate("Azure", null, "Sitecore");
        DoGenerate("Caching", null, "Sitecore");
        DoGenerate("CE Personalization", null, "Sitecore");
        DoGenerate("Content Editor", null, "Sitecore");
        DoGenerate("Dashboard", null, "Sitecore");
        DoGenerate("Data Providers API (Oracle, MS SQL)", null, "Sitecore");
        DoGenerate("Diagnostics (logging, counters)", null, "Sitecore");
        DoGenerate("EAS", null, "Sitecore");
        DoGenerate("Events", null, "Sitecore");
        DoGenerate("Item Clones", null, "Sitecore");
        DoGenerate("Item API", null, "Sitecore");
        DoGenerate("Jobs", null, "Sitecore");
        DoGenerate("Localization", null, "Sitecore");
        DoGenerate("Media", null, "Sitecore");
        DoGenerate("Modules", null, "Sitecore");
        DoGenerate("Multi Variant Testing", null, "Sitecore");
        DoGenerate("OMS\\DMS", null, "Sitecore");
        DoGenerate("OMS\\DMS Reports", null, "Sitecore");
        DoGenerate("Packager\\Installer", null, "Sitecore");
        DoGenerate("Page Editor", null, "Sitecore");
        DoGenerate("Page Level Testing", null, "Sitecore");
        DoGenerate("PE Personalization", null, "Sitecore");
        DoGenerate("Pipelines", null, "Sitecore");
        DoGenerate("Publishing API\\Architecture", null, "Sitecore");
        DoGenerate("Query API", null, "Sitecore");
        DoGenerate("Rad Editor", null, "Sitecore");
        DoGenerate("Rendering Engine(Helpres, Pipeline)", null, "Sitecore");
        DoGenerate("RSS", null, "Sitecore");
        DoGenerate("Search(Lucene,UI)", null, "Sitecore");
        DoGenerate("Security Model", null, "Sitecore");
        DoGenerate("Serialization", null, "Sitecore");
        DoGenerate("Setup", null, "Sitecore");
        DoGenerate("Sheer UI API", null, "Sitecore");
        DoGenerate("Sheer XAML", null, "Sitecore");
        DoGenerate("Sheer XML", null, "Sitecore");
        DoGenerate("Remote Eventing", null, "Sitecore");
        DoGenerate("UPT", null, "Sitecore");
        DoGenerate("Validation", null, "Sitecore");
        DoGenerate("WebDAV", null, "Sitecore");
        DoGenerate("Word OCX", null, "Sitecore");
        DoGenerate("Workflow concept + API", null, "Sitecore");

        DoGenerate("Ajax", null, "Development");
        DoGenerate("APP domains", null, "Development");
        DoGenerate("Data Structure", null, "Development");
        DoGenerate("Delegate and Events", null, "Development");
        DoGenerate("Entity Framework", null, "Development");
        DoGenerate("HTML\\CSS", null, "Development");
        DoGenerate("Java Script", null, "Development");
        DoGenerate("JQuery", null, "Development");
        DoGenerate("Lambda Expression", null, "Development");
        DoGenerate("LINQ", null, "Development");
        DoGenerate("MVC", null, "Development");
        DoGenerate("PL\\SQL", null, "Development");
        DoGenerate("Prototype", null, "Development");
        DoGenerate("Secutiry", null, "Development");
        DoGenerate("Serialization", null, "Development");
        DoGenerate("Threading", null, "Development");
        DoGenerate("TSQL", null, "Development");
        DoGenerate("User Controls", null, "Development");
        DoGenerate("Web Services", null, "Development");

        DoGenerate("Database Development", null, "Architecture");
        DoGenerate("Design patterns", null, "Architecture");
        DoGenerate("Inversion of Control", null, "Architecture");
        DoGenerate("Web Farms", null, "Architecture");
        DoGenerate("UI/UX", null, "Architecture");

        DoGenerate("AgentJohnson", null, "SE Tools and Libraries");
        DoGenerate("Browsers Dev. Tools", null, "SE Tools and Libraries");

        DoGenerate("SCRUM", null, "Processes");
        DoGenerate("TDD", null, "Processes");
        DoGenerate("Unit Testing", null, "Processes");
        DoGenerate("Pair Programming", null, "Processes");
        DoGenerate("Code Review", null, "Processes");

        DoGenerate("IIS", null, "Environment (Setup and Configuring)");
        DoGenerate("Oracle", null, "Environment (Setup and Configuring)");
        DoGenerate("MS SQL SERVER", null, "Environment (Setup and Configuring)");

        DoGenerate("Writing test cases", null, "Manual Testing");

        DoGenerate("Communication", null, "Management");
      }
      finally
      {
        UnitOfWork.Save();
      }

      return InsertedRecords;
    }

    protected virtual void DoGenerate(string name, string description, string skillGroupName)
    {
      var sgroup =
        UnitOfWork.SkillGroupRepository.Get(sg => string.Compare(sg.Name, skillGroupName, StringComparison.InvariantCultureIgnoreCase) == 0)
                  .FirstOrDefault();
      if (sgroup == null)
      {
        throw new Exception(string.Format("Skill Group with name '{0}' not found.", skillGroupName));
      }

      var skill = new Skill
        {
          Id = Guid.NewGuid(),
          Description = description,
          Name = name,
          GroupId = sgroup.Id
        };

      UnitOfWork.SkillRepository.Insert(skill);
      IncrementInsertedRecords();
    }
  }
}

