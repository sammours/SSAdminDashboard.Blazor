namespace SSAdminDashboard.Blazor;

using SSAdminDashboard.Domain;

internal class KeyCloakConfigurations(
    string clientId,
    string realm,
    string clientSecret,
    string serverUrl,
    bool requireHttpsMetadata) : IKeyCloakConfigurations
{
    public string ClientId { get; set; } = clientId;
    public string Realm { get; set; } = realm;
    public string ClientSecret { get; set; } = clientSecret;
    public string ServerUrl { get; set; } = serverUrl;
    public bool RequireHttpsMetadata { get; set; } = requireHttpsMetadata;
    
    internal static KeyCloakConfigurations Create(IConfiguration configuration)
        => new(
            configuration.GetValue<string>("Keycloak:ClientId") ?? string.Empty,
            configuration.GetValue<string>("Keycloak:Realm") ?? string.Empty,
            configuration.GetValue<string>("Keycloak:ClientSecret") ?? string.Empty,
            configuration.GetValue<string>("Keycloak:ServerUrl") ?? string.Empty,
            configuration.GetValue<bool>("Keycloak:RequireHttpsMetadata"));
}