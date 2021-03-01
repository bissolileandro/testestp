using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TesteSoftPlan.Service.Interface;

namespace TesteSoftPlan.Service.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        public CalculaJurosService()
        {

        }

        public async Task<string> CalcularJuros(decimal ValorInicial, int Meses)
        {
            decimal ValorFinal = 0;
            decimal juros = Convert.ToDecimal(await ObterTaxaDeJuros());
            ValorFinal = ValorInicial * (Convert.ToDecimal(Math.Pow(Convert.ToDouble((1 + juros)), Meses)));
            return ValorFinal.ToString("N2");
        }

        public string ShowMeTheCode()
        {
            return "https://github.com/bissolileandro/testestp.git";
        }

        private async Task<string> ObterTaxaDeJuros()
        {
            dynamic juros = "";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57384/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/taxaJuros");
                if (response.IsSuccessStatusCode)
                {
                   
                    var retorno = response.Content.ReadAsStringAsync();
                    juros = JsonConvert.DeserializeObject(retorno.Result);

                }
            }
            return juros;
        }
    }
}
