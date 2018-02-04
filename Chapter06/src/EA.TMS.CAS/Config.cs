using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EA.TMS.CAS
{
    public class Config
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {

                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Roles,
                StandardScopes.Email,
                StandardScopes.OfflineAccess,
                new Scope {
                    Name = "tmsAPI",
                    DisplayName = "TMS API",
                    Description = "TMS API",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim> {
                        new ScopeClaim(JwtClaimTypes.Role)
                    }
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "tmsWebApp",
                    ClientName ="TMS Web App",
                    AllowedGrantTypes= GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:5000/signin-oidc" },
                    PostLogoutRedirectUris= {"http://localhost:5000"},
                    Enabled=true,
                    AccessTokenType=  AccessTokenType.Jwt,
                    RequireConsent=true,
                    AllowedScopes =new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.OfflineAccess.Name,
                        "role"
                    },
                    AllowAccessToAllScopes=true
                },
                new Client
                {
                    ClientId = "tmsAPI",
                    ClientName ="TMS API",
                    AllowedGrantTypes= GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:5001/signin-oidc" },
                    PostLogoutRedirectUris= {"http://localhost:5001"},
                    Enabled=true,
                    RequireConsent=true,
                    AccessTokenType=  AccessTokenType.Jwt,
                    AllowedScopes =new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.OfflineAccess.Name,
                        "role"
                    },
                    AllowAccessToAllScopes=true
                }
            };
        }

        public static List<InMemoryUser> GetUsers()
        {

            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "00001",
                    Username = "ovais",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "scott"),
                        new Claim("given_name","scott edward"),
                        new Claim("family_name", "edward"),
                        new Claim("website", "www.scottdeveloper.com"),
                        new Claim("email", "scott@mailxyz.com"),
                        new Claim("role","admin"),

                    },
                },
                new InMemoryUser
                {
                    Subject = "2",
                    Username = "khusro",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim("role","user")
                    }

                }
            };
        }

    }
}
