using Erp100Af.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Erp100Af.Infrastructure.Persistence.Identity
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        
    }
}
