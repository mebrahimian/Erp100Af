using Erp100Af.Domain.Entities.Accounting;

namespace Erp100Af.Application.Accounting.Interfaces
{
    public interface ISegmentDefinitionService
    {
        Task<IEnumerable<SegmentDefinition>> GetAllAsync();
        Task<SegmentDefinition?> GetByIdAsync(Guid id);
        Task CreateAsync(SegmentDefinition segmentDefinition);
        Task UpdateAsync(SegmentDefinition segmentDefinition);
        Task DeleteAsync(Guid id);
    }

}
