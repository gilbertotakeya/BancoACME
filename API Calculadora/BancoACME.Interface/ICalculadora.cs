using System;
using System.Threading.Tasks;

namespace BancoACME.Interface
{
    public interface ICalculadora
    {
        Task<double> calculaJuros(double valorInicial, double meses);
    }
}