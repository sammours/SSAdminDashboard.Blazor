namespace SSAdminDashboard.Blazor.Authentication;

using Microsoft.AspNetCore.Authentication;
using SSAdminDashboard.Domain.Users;
using System.Security.Claims;

public class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    private readonly HttpContext context = contextAccessor?.HttpContext ?? throw new NullReferenceException("Context accessor is null");

    public string GetUserName() => this.GetClaimValue("name");
    public string GetUserId() => this.GetClaimValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
    public async Task<string> GetAccessTokenAsync()
        => await this.context.GetTokenAsync("access_token") ?? string.Empty;

    public UserRoles GetRole()
    {
        var roles = this.context.User.Claims.Where(x => x.Type == ClaimTypes.Role)
            .Select(x => x.Value) ?? new List<string>(); 

        if (roles.Any(x => x == "blazor-admin"))
        {
            return UserRoles.Admin;
        }

        if (roles.Any(x => x == "blazor-user"))
        {
            return UserRoles.User;
        }

        return UserRoles.User;
    }

    public bool IsAdmin() => this.GetRole() == UserRoles.Admin;
    public bool IsUser() => this.GetRole() == UserRoles.User;

    private string GetClaimValue(string type) =>
        this.context.User.Claims.FirstOrDefault(x => x.Type == type)?.Value
             ?? string.Empty;
}