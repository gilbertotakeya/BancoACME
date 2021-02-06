using BancoACME.Interface;
using System;
using System.Threading.Tasks;

namespace BancoACME.Repositorio
{
    public class DadosFinanceiros : IDadosFinanceiros
    {
        public async Task<double> taxaJuros()
        {
            //var taxa = await TaxaViaBancoDados();
            return 0.01;
        }
    }
}