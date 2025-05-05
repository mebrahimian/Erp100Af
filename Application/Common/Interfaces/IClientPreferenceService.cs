using Erp100Af.Application.Common.Dtos;

namespace Erp100Af.Application.Common.Interfaces
{
    public interface IClientPreferenceService
    {
        ClientPreferenceDto Preference { get; }
        Task LoadAsync();
        Task SaveAsync();
    }

}
