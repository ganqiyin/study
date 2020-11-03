using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace ClientCredentials.WebApi
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
         }
        };
    }
}
