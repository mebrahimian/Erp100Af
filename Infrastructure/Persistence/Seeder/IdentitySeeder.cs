using Erp100Af.Domain.Entities;
using Erp100Af.Domain.Entities.Identity;
using Erp100Af.Infrastructure.Persistence.App;
using Erp100Af.Infrastructure.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace Erp100Af.Infrastructure.Persistence.Seeder
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,
                                           RoleManager<ApplicationRole> roleManager,
                                           AppIdentityDbContext context)
        {
            // Step 1: ایجاد tenant پیش‌فرض
            var defaultTenantId = 1;
            if (!context.Tenants.Any(t => t.Id == defaultTenantId))
            {
                var tenant = new Tenant
                {
                    Name = "Default Tenant",
                    Code = "DEF",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedBy = "System",
                    CreatedOn = DateTime.UtcNow,
                    IsRemoved = false
                };
                context.Tenants.Add(tenant);
                await context.SaveChangesAsync();
            }

            // Step 2: ایجاد نقش‌ها
            var roles = new[] { "SuperAdmin", "TenantAdmin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole(role));
                }
            }

            // Step 3: ایجاد کاربر سوپرادمین
            var superAdminEmail = "superadmin@erp.local";
            var superAdmin = await userManager.FindByEmailAsync(superAdminEmail);
            if (superAdmin == null)
            {
                superAdmin = new ApplicationUser
                {
                    UserName = "superadmin",
                    Email = superAdminEmail,
                    EmailConfirmed = true,
                    TenantId = defaultTenantId
                };

                var result = await userManager.CreateAsync(superAdmin, "SuperAdmin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                }
                else
                {
                    throw new Exception($"SuperAdmin creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }

}
