using System;
using System.Threading.Tasks;

namespace BancoACME.Interface
{
    public interface IDadosFinanceiros
    {
        Task<double> taxaJuros();
    }
}