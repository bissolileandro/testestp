using System;
using System.Threading.Tasks;
using TesteSoftPlan.Domain;
using TesteSoftPlan.Service.Interface;

namespace TesteSoftPlan.Service.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        public TaxaDeJurosService()
        {

        }

        public async Task<string> ObterTaxa()
        {
            return TaxaDeJuros.PercentualDeTaxaDeJuros.ToString("N2");
        }
    }
}
