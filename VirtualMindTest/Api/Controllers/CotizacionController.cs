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
            var response = await quotationDomain.GetQuotation(id);

            if (response.HasError)
            {
                return Content((HttpStatusCode)response.CodeError, response.Message);
            }

            return Ok(response.ObjectResponse);
        }
    }
}
