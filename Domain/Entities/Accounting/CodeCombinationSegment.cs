namespace Erp100Af.Domain.Entities.Accounting;

public class CodeCombinationSegment
{
    public int Id { get; set; }

    public int CodeCombinationId { get; set; }
    public CodeCombination? CodeCombination { get; set; }

    public int SegmentDefinitionId { get; set; }
    public SegmentDefinition? SegmentDefinition { get; set; }

    public int SegmentValueId { get; set; }
    public SegmentValue? SegmentValue { get; set; }
}
