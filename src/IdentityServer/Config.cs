using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client()
        {
            ClientId = "moviesClient",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets =
            {
                new Secret("movies_api_secret_key".Sha256())
            },
            AllowedScopes = { "moviesAPI" }
        },
        new Client()
        {
            ClientId = "moviesMVCWebAppClient",
            ClientName = "Movies MVC Web App",
            AllowedGrantTypes = GrantTypes.Hybrid,
            RequirePkce = false,
            AllowRememberConsent = false,
            RedirectUris = {
                "https://localhost:5002/signin-oidc"
            },
            PostLogoutRedirectUris = {
                "https://localhost:5002/signout-callback-oidc"
            },
            ClientSecrets =
            {
                new Secret("movies_mvc_web_app_secret_key".Sha256())
            },
            AllowedScopes = new List<string>()
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Address,
                IdentityServerConstants.StandardScopes.Email,
                "roles",
                "moviesAPI"
            }
        }
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("moviesAPI", "Movies API")
    };

    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Address(),
        new IdentityResources.Email(),
        new IdentityResource()
        {
            Name = "roles",
            DisplayName = "Roles",
            UserClaims = new List<string>() { "role" }
        }
    };
}
