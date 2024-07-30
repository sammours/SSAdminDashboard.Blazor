#pragma warning disable SA1200 // Using directives should be placed correctly
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Logging;
using MudBlazor;
using MudBlazor.Services;
using SSAdminDashboard.Blazor;
using SSAdminDashboard.Blazor.Authentication;
using SSAdminDashboard.Blazor.Middlewares;
using SSAdminDashboard.Domain;
using SSAdminDashboard.Domain.Users;
using SSAdminDashboard.Infrastructure;
#pragma warning restore SA1200 // Using directives should be placed correctly


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddSingleton<IKeyCloakConfigurations>(opt =>
    KeyCloakConfigurations.Create(opt.GetRequiredService<IConfiguration>()));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.RegisterDatabase();
builder.Services.RegisterRepositories();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterKeyCloak();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
