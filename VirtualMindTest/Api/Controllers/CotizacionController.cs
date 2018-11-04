using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class CotizacionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(new { message = "Success!" });
        }
    }
}
