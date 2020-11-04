using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace UserPassword.Hosting.WebApi
{
    public class Config
    {
        //范围（Scopes）用来定义系统中你想要保护的资源，比如 API。
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> {
          new ApiScope("api1","我的API")
        };

        // 定义能够访问上述(ApiScopes) API 的客户端
        public static IEnumerable<Client> Clients => new List<Client> {
         new Client{
           ClientId="client",
           // no interactive user, use the clientid/secret for authentication
           // 没有交互性用户，使用 clientid/secret 实现认证。
           AllowedGrantTypes=GrantTypes.ClientCredentials,
             // secret for authentication
             // 用于认证的密码
             ClientSecrets =
             {
                 new Secret("secret".Sha256())
             }, 
             // scopes that client has access to
             // 客户端有权访问的范围（Scopes）
            AllowedScopes = { "api1" }
         },new Client
         {
              ClientId="mvc",
              ClientSecrets=
             { 
                 new Secret("secret".Sha256())
             },
              AllowedGrantTypes=GrantTypes.Code,
               //AccessTokenType = AccessTokenType.Reference,
               //RequireConsent = true,
               //     RequirePkce = true,
               // where to redirect to after login
            RedirectUris = { "https://localhost:6001/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:6001/signout-callback-oidc" },

            AllowedScopes = new List<string>
            {
                //"api1",
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            }
         }
        };

        public static List<TestUser> GetUsers => new List<TestUser> { 
          new TestUser{ SubjectId="1",Username="Lyra1",Password="123Qwe"},
          new TestUser{ SubjectId="2",Username="Lyra2",Password="123Qwe"}
        };
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "alice",
                        Password = "alice",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "bob",
                        Password = "bob",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
        public static List<IdentityResource> IdentityResources => new List<IdentityResource> { 
          new IdentityResources.OpenId(),
          new IdentityResources.Profile()
        };
    }
}
