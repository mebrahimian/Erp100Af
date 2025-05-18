using Microsoft.AspNetCore.Identity;

namespace Erp100Af.Domain.Entities.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
