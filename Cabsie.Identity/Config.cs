using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Cabsie.Identity
{
    internal class Clients
    {
        public const string MAIN_CLIENT_ID = "Cabsie.API";
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = MAIN_CLIENT_ID,
                    ClientName = "Main Cabsie API",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "role",
                        "customAPI.write"
                    },
                    RedirectUris = new List<string> 
                    {
                        "https://localhost:5001/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string> 
                    {
                        "https://localhost:5001"
                    }
                }
            };
        }
    }

    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource {
                    Name = Clients.MAIN_CLIENT_ID,
                    DisplayName = "Cabsie API",
                    Description = "Cabsie API Access",
                    UserClaims = new List<string> { "role" },
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("scopeSecret".Sha256())
                    },
                    Scopes = new List<Scope>
                    {
                        new Scope("cabsie.API.read"),
                        new Scope("cabsie.API.write")
                    }
                }
            };
        }
    }

    internal class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "flour",
                    Password = "Hello12",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "vs@sys.im"),
                        new Claim(JwtClaimTypes.PhoneNumber, "+79788831273"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}

