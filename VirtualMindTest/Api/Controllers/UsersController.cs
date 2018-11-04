using Domain;
using Domain.Impl;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserDomain userDomain;

        public UsersController()
        {
            userDomain = new UserDomain();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await userDomain.GetAll());
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            var result = await userDomain.Create(user);
            return Ok(result);
        }
    }
}
