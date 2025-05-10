using Erp100Af.Domain.Entities.Accounting;

namespace Erp100Af.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface ISegmentDefinitionRepository : IGeneralRepository<SegmentDefinition>
    {
        Task<List<SegmentDefinition>> GetAllWithChildrenAsync(int tenantId);
    }
}
