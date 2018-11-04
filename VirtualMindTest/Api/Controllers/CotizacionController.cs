using Core.CrossException;
using Core.QuotationException;
using Domain;
using Domain.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class CotizacionController : ApiController
    {
        private readonly IQuotationDomain quotationDomain;

        public CotizacionController()
        {
            quotationDomain = new QuotationDomain();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var response = await quotationDomain.GetQuotation(id);
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
