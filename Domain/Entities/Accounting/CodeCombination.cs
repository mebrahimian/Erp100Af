namespace Erp100Af.Domain.Entities.Accounting;

public class CodeCombination
{
    public int Id { get; set; }

    public List<CodeCombinationSegment> Segments { get; set; } = new();
}

