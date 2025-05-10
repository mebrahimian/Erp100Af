using Microsoft.AspNetCore.Identity;

namespace Erp100Af.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }

}
