namespace Erp100Af.Application.Common.Interfaces
{
    public interface IClientPreferenceService
    {
        Task LoadAsync();
        Task SaveAsync();

        string Language { get; set; }
        bool IsRtl { get; set; }
        bool IsDarkMode { get; set; }
        string Theme { get; set; }
        bool IsDrawerOpen { get; set; }
    }

}
