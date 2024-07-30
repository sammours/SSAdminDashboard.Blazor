namespace SSAdminDashboard.Domain.Users;

public interface IUserService
{
    string GetUserName();
    UserRoles GetRole();
    Task<string> GetAccessTokenAsync();
    bool IsAdmin();
    bool IsUser();
}