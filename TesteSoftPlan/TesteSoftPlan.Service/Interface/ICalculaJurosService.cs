using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteSoftPlan.Service.Interface
{
    public interface ICalculaJurosService
    {
        Task<string> CalcularJuros(decimal ValorInicial, int Meses);
        string ShowMeTheCode();
    }
}
