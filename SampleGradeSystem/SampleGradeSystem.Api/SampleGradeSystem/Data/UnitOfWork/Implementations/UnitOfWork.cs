using Microsoft.EntityFrameworkCore;
using SampleGradeSystem.Data.Repositories.Implementations;
using SampleGradeSystem.Data.Repositories.Interfaces;
using SampleGradeSystem.Data.UnitOfWork.Interfaces;

namespace SampleGradeSystem.Data.UnitOfWork.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(DbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T> Repository<T>() where T : class
    {
        if (!_repositories.ContainsKey(typeof(T)))
        {
            _repositories[typeof(T)] = new Repository<T>(_context);
        }
        return (IRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

