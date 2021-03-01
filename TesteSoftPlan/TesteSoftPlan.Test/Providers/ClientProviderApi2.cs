using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TesteSoftPlan.Api2;

namespace TesteSoftPlan.Test.Providers
{
    public class ClientProviderApi2 : IDisposable
    {
        
        public HttpClient client { get; private set; }
        public TestServer server;
        public ClientProviderApi2()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            client?.Dispose();
        }
    }
}
