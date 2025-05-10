using MyBlazorApplication.Domain.Contracts;

namespace Erp100Af.Domain.Entities.Accounting;

public class CodeCombination : AuditableEntity<int>
{
    public int TenantId { get; set; }
    public List<CodeCombinationSegment> Segments { get; set; } = new();
}

