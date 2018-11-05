using Core.UserException;
using DataAccess.UserActions;
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
            userDomain = new UserDomain(new UserAction());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await userDomain.GetAll());
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            try
            {
                return Ok(await userDomain.GetById(id));
            } catch (UserIdNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            var result = await userDomain.Create(user);
            return Content(HttpStatusCode.Created, result);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(string id, [FromBody]User user)
        {
            try
            {
                return Ok(await userDomain.Update(id, user));
            }
            catch (UserIdNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            try
            {
                await userDomain.Delete(id);
                return Ok();
            } catch (UserIdNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
