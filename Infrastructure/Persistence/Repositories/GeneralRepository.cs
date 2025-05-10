using Erp100Af.Domain.Entities.Accounting;
using Erp100Af.Infrastructure.Persistence;
using Erp100Af.Infrastructure.Persistence.App;
using Erp100Af.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Erp100Af.Infrastructure.Persistence.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GeneralRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Entities => _dbSet.AsNoTracking();

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public async Task<List<SegmentDefinition>> GetAllWithChildrenAsync(int tenantId)
        {
            return await _context.SegmentDefinitions
                .Where(s => s.TenantId == tenantId)
                .Include(s => s.ParentSegmentId)
                .ToListAsync();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SegmentDefinition>> GetAllWithChildrenAsync(Guid tenantId)
        {
            throw new NotImplementedException();
        }
    }
}
