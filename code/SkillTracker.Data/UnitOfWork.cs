using System;
using System.Diagnostics.Contracts;
using SkillTracker.Data.Repositories;

namespace SkillTracker.Data
{
  public class UnitOfWork : IDisposable
  {
    private readonly SkillTrackerContext _context = new SkillTrackerContext();
    private GenericRepository<Department> _departmentRepository;
    private GenericRepository<Team> _teamRepository;
    private GenericRepository<Position> _positionRepository;
    private GenericRepository<SkillGroup> _skillGroupRepository;
    private GenericRepository<Skill> _skillRepository;
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

    public virtual GenericRepository<Team> TeamRepository
    {
      get
      {
        if (_teamRepository == null)
        {
          _teamRepository = new GenericRepository<Team>(_context);
        }

        return _teamRepository;
      }
    }

    public virtual GenericRepository<Position> PositionRepository
    {
      get
      {
        if (_positionRepository == null)
        {
          _positionRepository = new GenericRepository<Position>(_context);
        }

        return _positionRepository;
      }
    }

    public virtual GenericRepository<SkillGroup> SkillGroupRepository
    {
      get
      {
        if (_skillGroupRepository == null)
        {
          _skillGroupRepository = new GenericRepository<SkillGroup>(_context);
        }

        return _skillGroupRepository;
      }
    }

    public virtual GenericRepository<Skill> SkillRepository
    {
      get
      {
        if (_skillRepository == null)
        {
          _skillRepository = new GenericRepository<Skill>(_context);
        }

        return _skillRepository;
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
