using Erp100Af.Domain.Entities.Accounting;
using System.Linq.Expressions;

namespace Erp100Af.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> Entities { get; }

        Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<List<SegmentDefinition>> GetAllWithChildrenAsync(Guid tenantId);
    }
}
