using Erp100Af.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Erp100Af.Infrastructure.Persistence.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
