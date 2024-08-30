namespace SSAdminDashboard.Domain.Profiles;
using SSAdminDashboard.Domain.Users;
public interface IProfileRepository
{
    Task<(User user, Profile profile)> GetByUserIdAsync(string userId, CancellationToken cancellationToken);
    Task<Profile> UpdateAsync(Profile profile, CancellationToken cancellationToken);
}
