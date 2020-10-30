using Distribuicao.WebAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes.UnitTest.ContasPagarLancamentos
{
    public class ContasPagarWebApi
    {
        private readonly HttpClient _client;

        public ContasPagarWebApi()
        {
            string curDir = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(curDir)
                .AddJsonFile("appsettings.json");

            var server = new TestServer(new WebHostBuilder().UseContentRoot(curDir)
                                                            .UseConfiguration(builder.Build())
                                                            .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task ListarTodasAsContasPagarAsync(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/contaspagar");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("GET", 1)]
        public async Task BuscarContaPagarPorId(string method, int id)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/contaspagar/{id}");

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);            
        }                
    }
}
