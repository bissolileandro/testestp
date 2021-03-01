using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSoftPlan.Service.Interface;

namespace TesteSoftPlan.Api.Controllers
{
    [Route("api/taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public TaxaJurosController(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }
        [HttpGet]        
        [Route("")]
        public async Task<IActionResult> ObterTaxa()
        {
            try
            {
                var resultado = await _taxaDeJurosService.ObterTaxa();
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

    }
}
