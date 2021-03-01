using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TesteSoftPlan.Test.Providers;
using Xunit;

namespace TesteSoftPlan.Test
{
    public class CalculaJuros
    {
        [Fact]
        public async Task CalculaJurosApi()
        {
            using (var clientProvider = new ClientProviderApi2().client)
            {
                var response = await clientProvider.GetAsync("/api/calculajuros?valorinicial=100&meses=5");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK, "EndPoint Inexixtente! " +
                                                                   "Por favor Execute a Api de Taxa Separado");
            }
        }

        [Fact]
        public async Task ShowMeTheCodeApi()
        {
            using (var clientProvider = new ClientProviderApi2().client)
            {
                var response = await clientProvider.GetAsync("/api/showmethecode");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK, "EndPoint Inexixtente! " +
                                                                   "Por favor Execute a Api de Taxa Separado");
            }
        }

        [Fact]
        public async Task TestarCauculoJuros()
        {
            using (var clientProvider = new ClientProviderApi2().client)
            {
                var response = await clientProvider.GetAsync("/api/calculajuros?valorinicial=200&meses=13");
                response.EnsureSuccessStatusCode();
                
                var resultado = response.Content.ReadAsStringAsync();

                dynamic retorno = resultado.Result;

                decimal juros = Convert.ToDecimal(retorno);

                juros.Should().Be(227.62M, "Valor da Taxa esperado é de 227.62");
            }
        }
    }
}
