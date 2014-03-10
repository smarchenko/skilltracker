using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillTracker.Web.Services.Logging
{
  public interface ILogger
  {
    void Audit(string message);

    void Error(string message);

    void Error(string message, Exception exception);
  }
}