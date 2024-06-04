using System.Security.Claims;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer;

public static class Config
{
    //Resources
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    
    
    
    //Scopes
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { new ApiScope{
                Name="api1",
                DisplayName="My Api"}
            };


    
    //Clients
    public static IEnumerable<Client> Clients =>
        new Client[] 
            { 
                new Client{
                    ClientId="client",
                    ClientSecrets={new Secret("secret".Sha256())},
                     AllowedScopes={"api1"},
                     AllowedGrantTypes=GrantTypes.ClientCredentials},
                new Client{
                    ClientId="web",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    AllowedScopes={
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                    },

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                }
            };

    
    
    //Test Users
    public static List<TestUser>Users=>new List<TestUser>{
        new TestUser
        {
            Username="rana.anhar",
            Password="pass",
            SubjectId="5BE86359-073C-434B-AD2D-A3932222DABE",
            Claims=new List<Claim>{
                new Claim(JwtClaimTypes.Email, "rana.anhar@gmail.com"),
                new Claim(JwtClaimTypes.Role, "admin"),
            }
        }
    };

}