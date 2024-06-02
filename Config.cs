using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { new ApiScope{
                Name="api1",
                DisplayName="My Api"}
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            { new Client{
                ClientId="client",
                 ClientSecrets={new Secret("secret".Sha256())},
                 AllowedScopes={"api1"},
                 AllowedGrantTypes=GrantTypes.ClientCredentials}
            };
}