﻿namespace SSAdminDashboard.Blazor.Authentication;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

public static class KeyCloakCLaimsMapper
{
    public static void MapRolesToClaims(UserInformationReceivedContext context)
    {
        if (context.Principal?.Identity is not ClaimsIdentity claimsIdentity)
        {
            return;
        }

        if (context.User.RootElement.TryGetProperty("preferred_username", out var username))
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username.ToString()));
        }

        if (context.User.RootElement.TryGetProperty("realm_access", out var realmAccess)
            && realmAccess.TryGetProperty("roles", out var globalRoles))
        {
            foreach (var role in globalRoles.EnumerateArray())
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }
        }

        if (context?.Options?.ClientId is not null &&
            context.User.RootElement.TryGetProperty("resource_access", out var clientAccess)
            && clientAccess.TryGetProperty(context.Options.ClientId, out var client)
            && client.TryGetProperty("roles", out var clientRoles))
        {
            foreach (var role in clientRoles.EnumerateArray())
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }
        }
    }
}
