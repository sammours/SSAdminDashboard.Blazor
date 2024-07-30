namespace SSAdminDashboard.Infrastructure.UserManagements;

using SSAdminDashboard.Domain;
using SSAdminDashboard.Domain.Users;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;

public class UserProvider(
    IKeyCloakConfigurations configuration,
    IUserService userService,
    IHttpClientFactory factory) : IUserProvider
{
    private readonly IKeyCloakConfigurations configuration = configuration;
    private readonly IUserService userService = userService;
    private readonly IHttpClientFactory factory = factory;

    public async Task<int> GetCountAsync(string term, CancellationToken cancellationToken)
    {
        var httpClient = await this.GetHttpClientAsync();
        var response = await httpClient.GetAsync($"{this.configuration.ApiUrl}/users/count?search={term}", cancellationToken);
        return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : 0;
    }

    public async Task<List<User>> GetAllUsersAsync(int take, int skip, string term, CancellationToken cancellationToken)
    {
        var httpClient = await this.GetHttpClientAsync();
        var response = await httpClient.GetAsync($"{this.configuration.ApiUrl}/users?max={take}&first={skip}&search={term}", cancellationToken);
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
        }

        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<List<User>>()) ?? new();
        }

        return new();
    }

    public async Task<User> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var httpClient = await this.GetHttpClientAsync();
        var response = await httpClient.GetAsync($"{this.configuration.ApiUrl}/users/{id}", cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<User>()) ?? new();
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedUserProviderException();
        }

        throw new UserProviderException(string.Format("Couldn't find a user with id: {0}", id));
    }

    public async Task<User> InsertAsync(User user, CancellationToken cancellationToken)
    {
        user.Id = Guid.NewGuid().ToString();
        var httpClient = await this.GetHttpClientAsync();
        var response = await httpClient.PostAsJsonAsync($"{this.configuration.ApiUrl}/users", user, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return user;
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedUserProviderException();
        }

        throw new UserProviderException("User cannot be inserted");
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        var httpClient = await this.GetHttpClientAsync();
        var response = await httpClient.PutAsJsonAsync($"{this.configuration.ApiUrl}/users/{user.Id}", user, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return user;
        }

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedUserProviderException();
        }

        throw new UserProviderException("User cannot be updated");
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var httpClient = await this.GetHttpClientAsync();
        var response = await httpClient.DeleteAsync($"{this.configuration.ApiUrl}/users/{id}", cancellationToken);
        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedUserProviderException();
        }

        return response.IsSuccessStatusCode;
    }

    private async Task<HttpClient> GetHttpClientAsync()
    {
        var token = await this.userService.GetAccessTokenAsync();
        var httpClient = this.factory.CreateClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        return httpClient;
    }
}
