using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GR.IdentityServer.Hosting
{
    public class IdentityServerOption
    {
        public List<ApiScopeOption> ApiScopes { get; set; }

        public List<ClientOption> Clients { get; set; }
    }

    public class ClientOption
    {
        public string Id { get; set; }
        public string GrantTypes { get; set; }
        public string Secrets { get; set; }
        public string Scopes { get; set; } 
    }

    public class ApiScopeOption
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
