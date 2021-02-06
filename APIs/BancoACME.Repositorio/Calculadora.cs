using BancoACME.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoACME.Repositorio
{
    public class Calculadora : ICalculadora
    {
        public async Task<double> calculaJuros(double valorInicial, double meses)
        {
            IDadosFinanceiros dadosFinanceiros = new DadosFinanceiros();

            var taxaJuros = await dadosFinanceiros.taxaJuros();

            var valorFinal = valorInicial * (1 + taxaJuros) * meses;

            return valorFinal;
        }
    }
}