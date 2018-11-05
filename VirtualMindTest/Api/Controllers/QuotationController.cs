using Core.CrossException;
using Core.QuotationException;
using Domain;
using Domain.Impl;
using Domain.Impl.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class QuotationController : ApiController
    {
        private readonly IQuotationDomain quotationDomain;
        private readonly ApiClient apiClient;

        public QuotationController()
        {
            apiClient = new ApiClient(new HttpClient());
            quotationDomain = new QuotationDomain(apiClient);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string currency)
        {
            try
            {
                var response = await quotationDomain.GetQuotation(currency);
                return Ok(response);
            }
            catch (NotExistCurrencyIdException ex)
            {
                return Content(HttpStatusCode.BadRequest, new { ErrorMessage = ex.Message });
            }
            catch (NotAvailableCurrencyException ex)
            {
                return Content(HttpStatusCode.Unauthorized, new { ErrorMessage = ex.Message });
            }
            catch (CrossException ex)
            {
                return Content(HttpStatusCode.ServiceUnavailable, new { ErrorMessage = ex.Message });
            }
        }    
    }
}
