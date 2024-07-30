namespace SSAdminDashboard.Blazor.Authentication;

using Microsoft.AspNetCore.Authentication;
using SSAdminDashboard.Domain.Users;
using System.Security.Claims;

public class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    private readonly HttpContext context = contextAccessor?.HttpContext ?? throw new NullReferenceException("Context accessor is null");

    public string GetUserName() => this.GetClaimValue("name");
    public async Task<string> GetAccessTokenAsync()
        => await this.context.GetTokenAsync("access_token") ?? string.Empty;

    public UserRoles GetRole()
    {
        var role = this.GetClaimValue(ClaimTypes.Role);

        return role switch
        {
            "blazor-admin" => UserRoles.Admin,
            "blazor-user" => UserRoles.User,
            _ => UserRoles.User
        };
    }

    public bool IsAdmin() => this.GetRole() == UserRoles.Admin;
    public bool IsUser() => this.GetRole() == UserRoles.User;

    private string GetClaimValue(string type) =>
        this.context.User.Claims.FirstOrDefault(x => x.Type == type)?.Value
             ?? string.Empty;
}