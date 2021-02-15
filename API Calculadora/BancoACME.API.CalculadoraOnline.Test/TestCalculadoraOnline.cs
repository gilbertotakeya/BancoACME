using System;
using Xunit;
using BancoACME.API.CalculadoraOnline;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using BancoACME.API.Calculadora;
using System.Threading.Tasks;
using System.Net;

namespace BancoACME.API.CalculadoraOnline.Test
{
    public class TestCalculadoraOnline
    {
        private readonly HttpClient _cliente;

        public TestCalculadoraOnline()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Development")
                .UseStartup<Startup>());
            _cliente = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task TestarCalculoJuros(string method)
        {
            //arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/CalculoOnline/calculaJuros");

            //ação
            var response = await _cliente.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}