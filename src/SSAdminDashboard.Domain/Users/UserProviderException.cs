namespace SSAdminDashboard.Domain.Users;

public class UserProviderException(string message)
    : Exception(message: $"User provider: {message}")
{
}