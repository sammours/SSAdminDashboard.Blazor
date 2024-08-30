namespace SSAdminDashboard.Domain.Users;

public interface IUserService
{
    string GetUserName();
    string GetUserId();
    UserRoles GetRole();
    Task<string> GetAccessTokenAsync();
    bool IsAdmin();
    bool IsUser();
}