using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ViewModels;
using Domain.Impl.Constants;
using Domain.Impl.Formatters;
using System.Web.Configuration;
using System.Net.Http;
using Core.QuotationException;
using Core.CrossException;

namespace Domain.Impl
{
    public class QuotationDomain : IQuotationDomain
    {
        private readonly IDictionary<string, Func<string, Task<QuotationResponse>>> cotizationStrategy;
        private readonly HttpClient client;

        public QuotationDomain()
        {
            client = new HttpClient();
            cotizationStrategy = new Dictionary<string, Func<string, Task<QuotationResponse>>>();
            cotizationStrategy.Add(CurrencyType.DOLAR, GetDolarQuotation);
            cotizationStrategy.Add(CurrencyType.PESOS, GetRealQuotation);
            cotizationStrategy.Add(CurrencyType.REAL, GetPesosQuotation);
        }

        public async Task<QuotationResponse> GetQuotation(string currency)
        {
            try
            {
                return await cotizationStrategy[currency](currency);
            }
            catch (KeyNotFoundException)
            {
                var message = String.Format("El tipo de moneda {0} esta incorrecto o no esta contemplado. Los valores correctos son: '{1}', '{2}' y '{3}'",
                    currency, CurrencyType.PESOS, CurrencyType.REAL, CurrencyType.DOLAR);
                throw new NotExistCurrencyIdException(message);
            }
        }

        private Task<QuotationResponse> GetRealQuotation(string currency)
        {
            return GetUnhautorizedError(currency);
        }

        private Task<QuotationResponse> GetPesosQuotation(string currency)
        {
            return GetUnhautorizedError(currency);
        }

        private async Task<QuotationResponse> GetDolarQuotation(string currency)
        {
            var response = new QuotationResponse();
            var formatter = new QuotationFormatter();

            var uri = WebConfigurationManager.AppSettings["QuotationUrl"];
            var result = await client.GetAsync(uri);
            if (!result.IsSuccessStatusCode)
            {
                throw new CrossException("Ocurrió un problema al intentar obtener la cotización. Intente de nuevo mas tarde, por favor.");
            }

            var quotation = await result.Content.ReadAsAsync<List<string>>();
            response = formatter.ToQuotationResponse(quotation);
            return response;
        }

        private Task<QuotationResponse> GetUnhautorizedError(string curremcy)
        {
            throw new NotAvailableCurrencyException($"No autorizado para obtener información del tipo: {curremcy}.");
        }
    }
}
