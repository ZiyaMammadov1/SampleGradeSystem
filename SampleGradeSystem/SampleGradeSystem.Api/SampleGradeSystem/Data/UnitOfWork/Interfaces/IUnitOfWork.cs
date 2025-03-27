using SampleGradeSystem.Data.Repositories.Implementations;
using SampleGradeSystem.Data.Repositories.Interfaces;

namespace SampleGradeSystem.Data.UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;

    Task<int> SaveChangesAsync();
}
