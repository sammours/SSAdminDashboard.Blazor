namespace SSAdminDashboard.Domain;

public interface IKeyCloakConfigurations
{
    string ClientId { get; set; }
    string Realm { get; set; }
    string ClientSecret { get; set; }
    string ServerUrl { get; set; }
    bool RequireHttpsMetadata { get; set; }
    string Authority => string.Format("{0}/realms/{1}", this.ServerUrl, this.Realm);
    string ApiUrl => string.Format("{0}/admin/realms/{1}", this.ServerUrl, this.Realm);
}
