using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteSoftPlan.Service.Interface
{
    public interface ITaxaDeJurosService
    {
        Task<string> ObterTaxa();
    }
}
