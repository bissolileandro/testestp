using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSoftPlan.Service.Interface;

namespace TesteSoftPlan.Api.Controllers
{
    [Route("api/calculajuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        ICalculaJurosService _calculaJurosService;
        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> CalculaJuros(decimal valorinicial, int meses) 
        {
            try
            {
                var resultado = await _calculaJurosService.CalcularJuros(valorinicial, meses);
                return Ok(resultado);

            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}
