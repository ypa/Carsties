using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("auctionApp", "Auction app full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "postman",
                ClientName = "Postman",
                AllowedScopes = { "openid", "profile", "auctionApp" },
                RedirectUris = {"https://www.getpostman.com/oauth2/callback"},
                ClientSecrets = new[] {new Secret("NotASecret".Sha256())},
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword}
            },
            new Client
            {
                ClientId = "nextApp",
                ClientName = "nextApp",
                ClientSecrets = {new Secret("secret".Sha256())},
                // OAuth handshake can happen behind the scene over the network, no broswer involvement needed
                // For a mobile app client use GrantTypes.Code -- YP 08/17/2024
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                RequirePkce = false, // For a mobile app client use true -- YP 08/17/2024
                RedirectUris = {"http://localhost:3000/api/auth/callback/id-server"},
                AllowOfflineAccess = true, // For refresh token functionality -- YP 08/17/2024
                AllowedScopes = {"openid", "profile", "auctionApp"},
                AccessTokenLifetime = 3600*24*30 // During development mode keep it 30 days for now, default is one hour -- YP 08/17/2024
            }
        };
}
