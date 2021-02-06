using BancoACME.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoACME.API.CalculadoraOnline.Controllers
{
    [Route("[controller]")]
    public class CalculoOnlineController : Controller
    {
        ICalculadora Calculadora;
        public CalculoOnlineController(ICalculadora calculadora)
        {
            Calculadora = calculadora;
        }

        [HttpGet("CalculoJuros")]
        public async Task<ActionResult<double>> CalculoJuros()
        {
            return await Calculadora.calculaJuros(1000, 1);
        }
    }
}
