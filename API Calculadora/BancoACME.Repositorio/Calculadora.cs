using BancoACME.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BancoACME.Repositorio
{
    public class Calculadora : ICalculadora
    {
        public async Task<double> calculaJuros(double valorInicial, int meses)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
            using (HttpClient client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(30) })
            {
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var taxaJuros = 0.00;
                var servidor = "https://localhost:44309/DadosFinanceiros/TaxaJuros";
                var response = await client.GetAsync(servidor).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(response.ToString()))
                    {
                        var result = response.Content.ReadAsStringAsync();
                        taxaJuros = Convert.ToDouble(result.Result.Replace(".", ","));
                    }
                }

                var valorFinal = valorInicial * Math.Pow((1 + taxaJuros), meses);

                return valorFinal;
            }
        }

        public string showMeTheCode()
        {
            return "https://github.com/gilbertotakeya/BancoACME";
        }
    }
}