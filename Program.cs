using Erp100Af.Components;
using MudBlazor.Services;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Erp100Af.Shared.Constants.Localization;
using Blazored.LocalStorage;
using Erp100Af.Application.Common.Interfaces;
using Erp100Af.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Erp100Af.Infrastructure.Persistence.App;
using Erp100Af.Infrastructure.Persistence.Identity;
using Erp100Af.Domain.Entities.Identity;
using Erp100Af.Infrastructure.Persistence.Seeder;


var builder = WebApplication.CreateBuilder(args);
var supportedCultures = LocalizationConstants.SupportedLanguages
    .Select(lang => lang.Code)
    .ToArray();

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

// Add MudBlazor services
builder.Services.AddMudServices();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IClientPreferenceService, ClientPreferenceService>();
// Connection Data Base
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Connection Identity
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// „—»Êÿ »Â identity 
/////////////////////
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
////////////////////
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/auth/login";
    
});


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseRequestLocalization(localizationOptions);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
    var identityContext = services.GetRequiredService<AppIdentityDbContext>();

    await IdentitySeeder.SeedAsync(userManager,roleManager, identityContext);
}
app.Run();
