namespace SSAdminDashboard.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using SSAdminDashboard.Domain;
using SSAdminDashboard.Domain.Profiles;
using SSAdminDashboard.Domain.Users;

public class ProfileRepository(AdDbContext adDbContext, IUserProvider userProvider) : IProfileRepository
{
    private readonly AdDbContext adDbContext = adDbContext;
    private readonly IUserProvider userProvider = userProvider;

    public async Task<(User user, Profile profile)> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var user = (await this.userProvider.GetByIdAsync(userId, cancellationToken))
                ?? throw new ArgumentException("User with Id: {userId} couldn't be found", userId);
        
        var profile = (await this.adDbContext.Profiles
                .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken))
                ?? throw new ArgumentException("Profile with UserId: {userId} couldn't be found", userId);

        return (user, profile);
    }

    public async Task<Profile> UpdateAsync(Profile profile, CancellationToken cancellationToken)
    {
        if (profile == null)
        {
            throw new ArgumentException("Profile cannot be null");
        }

        var dbProfile = await this.adDbContext.Profiles.FindAsync(profile.Id, cancellationToken);
        if (dbProfile == null)
        {
            throw new ArgumentException("Profile with Id: {id} couldn't be found", profile.Id.ToString());
        }

        dbProfile.DateOfBirth = profile.DateOfBirth;
        dbProfile.IsBlocked = profile.IsBlocked;
        dbProfile.Position = profile.Position;
        dbProfile.Avatar = profile.Avatar;
        dbProfile.Role = profile.Role;
        await this.adDbContext.SaveChangesAsync(cancellationToken);
        return dbProfile;
    }
}
