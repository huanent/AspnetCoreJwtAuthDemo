using AspnetCoreJwtAuthDemo;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http.Headers;
using Xunit;

namespace FunctionalTests
{
    public class AuthControllerTests
    {
        [Fact]
        public void Token()
        {
            var host = new TestServer(
                WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
            var client = host.CreateClient();

            string token = client.GetStringAsync("api/auth/Token").Result;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }
    }
}
