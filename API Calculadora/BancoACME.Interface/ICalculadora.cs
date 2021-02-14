using System;
using System.Threading.Tasks;

namespace BancoACME.Interface
{
    public interface ICalculadora
    {
        string showMeTheCode();
        Task<double> calculaJuros(double valorInicial, int meses);
    }
}