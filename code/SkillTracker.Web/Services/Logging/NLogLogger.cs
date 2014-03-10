using System;
using System.Diagnostics.Contracts;
using System.IO;
using NLog;

namespace SkillTracker.Web.Services.Logging
{
  public class NLogLogger : ILogger
  {
    private readonly Logger _auditLogger;
    private readonly Logger _logger;

    protected virtual Logger AuditLogger
    {
      get { return this._auditLogger; }
    }

    protected virtual Logger Logger
    {
      get { return this._logger; }
    }

    public NLogLogger() : this("fileLog", "auditLog")
    {
    }

    public NLogLogger(string logName, string auditLogName)
    {
      Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(logName), "log name");
      Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(auditLogName), "audit log name");
      Contract.EnsuresOnThrow<InvalidDataException>(AuditLogger != null, "audit logger");
      Contract.EnsuresOnThrow<InvalidDataException>(Logger != null, "logger");

      this._auditLogger = LogManager.GetLogger(auditLogName);
      this._logger = LogManager.GetLogger(logName);
    }

    public virtual void Audit(string message)
    {
      this.AuditLogger.Info(message);
    }

    public virtual void Error(string message)
    {
      this.Logger.Error(message);
    }

    public virtual void Error(string message, Exception ex)
    {
      this.Logger.ErrorException(message, ex);
    }
  }
}