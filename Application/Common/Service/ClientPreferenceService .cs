using Blazored.LocalStorage;
using Erp100Af.Application.Common.Dtos;
using Erp100Af.Application.Common.Interfaces;
using Erp100Af.Application.Common.Dtos;
using Erp100Af.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace Erp100Af.Services;

public class ClientPreferenceService : IClientPreferenceService
{
    private const string StorageKey = "client-preferences";
    private readonly ILocalStorageService _localStorage;

    public string Language { get; set; } = "en-US";
    public bool IsRtl { get; set; } = false;
    public bool IsDarkMode { get; set; } = false;
    public string Theme { get; set; } = "default";
    public bool IsDrawerOpen { get; set; } = true;

    public ClientPreferenceService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task LoadAsync()
    {
        var preferences = await _localStorage.GetItemAsync<ClientPreferenceDto>(StorageKey);
        if (preferences is not null)
        {
            Language = preferences.Language;
            IsRtl = preferences.IsRtl;
            IsDarkMode = preferences.IsDarkMode;
            Theme = preferences.Theme;
            IsDrawerOpen = preferences.IsDrawerOpen;
        }
    }

    public async Task SaveAsync()
    {
        var dto = new ClientPreferenceDto
        {
            Language = Language,
            IsRtl = IsRtl,
            IsDarkMode = IsDarkMode,
            Theme = Theme,
            IsDrawerOpen = IsDrawerOpen
        };

        await _localStorage.SetItemAsync(StorageKey, dto);
    }
}
