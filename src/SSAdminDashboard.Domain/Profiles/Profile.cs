namespace SSAdminDashboard.Domain.Profiles;

using SSAdminDashboard.Domain.Users;
public class Profile : IEntity
{
    public long Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public bool IsBlocked { get; set; }
    public string Position { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public UserRoles Role { get; set; }
}
