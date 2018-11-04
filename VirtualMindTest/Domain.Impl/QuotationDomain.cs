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

namespace Domain.Impl
{
    public class QuotationDomain : IQuotationDomain
    {
        private readonly IDictionary<string, Func<Task<Response<QuotationResponse>>>> cotizationStrategy;

        public QuotationDomain()
        {
            cotizationStrategy = new Dictionary<string, Func<Task<Response<QuotationResponse>>>>();
            //cotizationStrategy.Add(CurrencyType.DOLAR, GetDolarQuotation);
            cotizationStrategy.Add(CurrencyType.PESOS, GetRealQuotation);
            cotizationStrategy.Add(CurrencyType.REAL, GetPesosQuotation);
        }

        public async Task<Response<QuotationResponse>> GetQuotation(string currency)
        {
            return new Response<QuotationResponse>
            {
                ObjectResponse = new QuotationResponse { PurchasePrice = 10, SalePrice = 20 }
            };
        }

        private Task<Response<QuotationResponse>> GetRealQuotation()
        {
            return GetUnhautorizedError();
        }

        private Task<Response<QuotationResponse>> GetPesosQuotation()
        {
            return GetUnhautorizedError();
        }

        //private async Task<Response<QuotationResponse>> GetDolarQuotation()
        //{
        //    var response = new Response<QuotationResponse>();
        //    var formatter = new QuotationFormatter();

        //    var uri = WebConfigurationManager.AppSettings["QuotationUrl"];
        //    var result = await client.GetAsync(uri);
        //    if (!result.IsSuccessStatusCode)
        //    {
        //        response.HasError = true;
        //        response.Message = "Ocurrió un problema al intentar obtener la cotización. Intente de nuevo mas tarde, por favor.";
        //        response.CodeError = 401;
        //        return response;
        //    }

        //    var quotation = await result.Content.ReadAsAsync<List<string>>();
        //    response.ObjectResponse = formatter.ToQuotationResponse(quotation);
        //    return response;
        //}

        private Task<Response<QuotationResponse>> GetUnhautorizedError()
        {
            return Task.FromResult(new Response<QuotationResponse>
            {
                HasError = true,
                Message = "Not authorized for this endpoint.",
                CodeError = 401
            });
        }
    }
}
