namespace Erp100Af.Application.Common.Dtos;

public class ClientPreferenceDto
{
    public string Language { get; set; } = "en-US";
    public bool IsRtl { get; set; } = false;
    public bool IsDarkMode { get; set; } = false;
    public string Theme { get; set; } = "default";
    public bool IsDrawerOpen { get; set; } = true;
}
