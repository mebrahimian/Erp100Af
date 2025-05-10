using Erp100Af.Infrastructure.Persistence.Repositories.Interfaces;
using Erp100Af.Domain.Entities.Accounting;
using Erp100Af.Infrastructure.Persistence.App;
using Erp100Af.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Erp100Af.Infrastructure.Persistence.Repositories
{
    public class SegmentDefinitionRepository : GeneralRepository<SegmentDefinition>, ISegmentDefinitionRepository
    {
        private readonly AppDbContext _context;

        public SegmentDefinitionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SegmentDefinition>> GetAllWithChildrenAsync(int tenantId)
        {
            return await _context.SegmentDefinitions
                .Where(s => s.TenantId == tenantId)
                .Include(s => s.ParentSegmentId) // در صورت وجود روابط
                .ToListAsync() ?? new List<SegmentDefinition>(); // البته این قسمت عملاً غیرضروریه چون ToListAsync هیچ‌وقت null نمی‌ده
        }
    }
}
