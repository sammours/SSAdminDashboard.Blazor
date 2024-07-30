namespace SSAdminDashboard.Domain.Users;

using SSAdminDashboard.Domain;

public interface IUserProvider
{
    Task<int> GetCountAsync(string term, CancellationToken cancellationToken);
    Task<List<User>> GetAllUsersAsync(int take, int skip, string term, CancellationToken cancellationToken);
    Task<User> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<User> InsertAsync(User user, CancellationToken cancellationToken);
    Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
}
