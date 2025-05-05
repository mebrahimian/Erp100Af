using Erp100Af.Components;
using MudBlazor.Services;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Erp100Af.Shared.Constants.Localization;

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

app.Run();
