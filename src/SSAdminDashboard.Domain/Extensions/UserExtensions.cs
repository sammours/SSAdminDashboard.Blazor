namespace SSAdminDashboard.Domain.Extensions;

using SSAdminDashboard.Domain.Users;

public static class UserExtensions
{
    public static string FullName(this User user)
    {
        if (user is null)
        {
            return string.Empty;
        }

        return string.Format("{0} {1}", user.FirstName, user.LastName);
    }
}
