using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillTracker.Web.Services.Logging;

namespace SkillTracker.Tests.Services
{
  public class Message
  {
    public string Level { get; set; }
    public string Text { get; set; }
  }

  public class FakeLogger : ILogger
  {
    List<Message> messages = new List<Message>();

    public List<Message> Messages
    {
      get { return this.messages; }
    }

    public void Audit(string message)
    {
      this.messages.Add(new Message{Level = "AUDIT", Text = message});
    }

    public void Error(string message)
    {
      this.messages.Add(new Message { Level = "ERROR", Text = message });
    }

    public void Error(string message, Exception ex)
    {
      this.messages.Add(new Message { Level = "ERROR", Text = message + Environment.NewLine + "Exception" + Environment.NewLine + ex.ToString() });
    }
  }
}
