using System;
using System.Diagnostics.Contracts;
using SkillTracker.Data.Repositories;

namespace SkillTracker.Data
{
  public class UnitOfWork : IDisposable
  {
    private readonly SkillTrackerContext _context = new SkillTrackerContext();
    private GenericRepository<Department> _departmentRepository;
    private bool _disposed = false;

    public UnitOfWork(SkillTrackerContext context)
    {
      Contract.Requires<ArgumentNullException>(context != null, "context");
      this._context = context;
    }

    public virtual GenericRepository<Department> DepartmentRepository
    {
      get
      {
        if (_departmentRepository == null)
        {
          _departmentRepository = new GenericRepository<Department>(_context);
        }

        return _departmentRepository;
      }
    }

    public void Save()
    {
      _context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this._disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
