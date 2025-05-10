using Blazored.LocalStorage;
using Erp100Af.Application.Common.Dtos;
using Erp100Af.Application.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Security.Cryptography.Xml;

namespace Erp100Af.Infrastructure.Services
{
    public class ClientPreferenceService : IClientPreferenceService
    {
        private readonly ILocalStorageService _localStorage;
        private const string Key = "clientPreference";
        public ClientPreferenceDto Preference { get; private set; } = new();

        public ClientPreferenceService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadAsync()
        {
            var loaded = await _localStorage.GetItemAsync<ClientPreferenceDto>(Key);
            Preference = loaded ?? new ClientPreferenceDto();
        }

        public async Task SaveAsync()
        {
            await _localStorage.SetItemAsync(Key, Preference);
        }
    }


}
