﻿namespace SSAdminDashboard.Domain.Users;

using System.Text.Json.Serialization;

public class User
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonPropertyName("username")]
    public string UserName { get; set; } = string.Empty;
}