namespace Erp100Af.Domain.Entities.Accounting;

public class SegmentValue
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;             // مثل: "001" یا "A12B"
    public string? Description { get; set; }                     // عنوان یا توضیح

    public int SegmentDefinitionId { get; set; }
    public SegmentDefinition? SegmentDefinition { get; set; }

    public int? ParentValueId { get; set; }
    public SegmentValue? ParentValue { get; set; }
}

