using System.Linq.Expressions;

namespace SampleGradeSystem.Data.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
