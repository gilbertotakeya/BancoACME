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

        [HttpGet("calculaJuros")]
        public async Task<ActionResult<double>> CalculoJuros(double ValorInicial, int quantidadeMeses)
        {
            if (ValorInicial <= 0)
                return 0;

            if (quantidadeMeses <= 0)
                return 0;

            return await Calculadora.calculaJuros(ValorInicial, quantidadeMeses);
        }

        [HttpGet("showMeTheCode")]
        public string ShowMeTheCode()
        {
            return Calculadora.showMeTheCode();
        }
    }
}
