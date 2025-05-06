namespace Erp100Af.Domain.Entities.Accounting;

public class SegmentDefinition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;             // مثلا: "Account"
    public string Code { get; set; } = string.Empty;             // مثلا: "ACCT"
    public int Order { get; set; }                               // ترتیب در ترکیب کدها
    public bool IsRequired { get; set; } = true;                 // اجباری بودن یا نه

    // "Numeric", "AlphaOnly", "Alphanumeric"
    public string DataType { get; set; } = "Alphanumeric";
    public int Length { get; set; } = 4;
    public bool PadLeftWithZero { get; set; } = false;           // صفر از چپ پر شود یا نه

    public string? DefaultValue { get; set; }
    public bool ShowDescription { get; set; } = true;

    public string? ValidationRegex { get; set; }                 // در صورت نیاز به کنترل خاص مثل ^[A-Z0-9]{4}$

    public int? ParentSegmentId { get; set; }
    public SegmentDefinition? ParentSegment { get; set; }
}
