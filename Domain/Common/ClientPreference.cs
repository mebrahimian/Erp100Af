namespace Erp100Af.Domain.Common
{
    public class ClientPreference
    {
        public string LanguageCode { get; set; } = "en-US";
        public bool IsDarkMode { get; set; } = false;
        public bool RightToLeft { get; set; } = false;
        public bool DrawerOpen { get; set; } = true;
        public string Theme { get; set; } = "BlazorErpTheme";
    }

}
