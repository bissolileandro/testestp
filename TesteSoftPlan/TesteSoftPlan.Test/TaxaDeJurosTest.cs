using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TesteSoftPlan.Test.Providers;

namespace TesteSoftPlan.Test
{
    public class TaxaDeJurosTest
    {
        [Fact]
        public async Task TesteTaxaDeJurosApi()
        {
            using (var clientProvider = new ClientProviderApi1().client)
            {
                var response = await clientProvider.GetAsync("/api/taxaJuros");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK, "EndPoint Inexixtente!");                
            }
        }

        [Fact]
        public async Task TesteValorDaTaxaDeJuros()
        {            
            using (var clientProvider = new ClientProviderApi1().client)
            {
                clientProvider.DefaultRequestHeaders.Accept.Clear();
                clientProvider.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await clientProvider.GetAsync("/api/taxaJuros");
                response.EnsureSuccessStatusCode();
                
                var resultado = response.Content.ReadAsStringAsync();

                dynamic retorno = JsonConvert.DeserializeObject(resultado.Result);
                
                decimal juros = Convert.ToDecimal(retorno);
                
                juros.Should().Be(0.01M, "Valor da Taxa esperado é de 0.01");
            }
        }
    }
}
