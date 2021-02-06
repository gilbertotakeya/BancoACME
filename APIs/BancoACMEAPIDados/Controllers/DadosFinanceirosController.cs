using BancoACME.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BancoACME.API.Dados.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class DadosFinanceirosController : ControllerBase
    {
        IDadosFinanceiros DadosFinanceiros;
        public DadosFinanceirosController(IDadosFinanceiros dadosFinanceiros)
        {
            DadosFinanceiros = dadosFinanceiros;
        }

        [HttpGet("TaxaJuros")]
        public async Task<ActionResult<double>> TaxaJuros()
        {
            return await DadosFinanceiros.taxaJuros();
        }
    }
}
