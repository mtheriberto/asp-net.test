using AspNet.Test.Business;
using AspNet.Test.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNet.Test.Web.Controllers.Api.v1
{
    [RoutePrefix("api/v1/account")]
    public class AccountController : ApiController
    {
        private readonly UserBusiness _userBusiness;

        public AccountController()
        {
            // TODO: Implements Dependency Injection
            this._userBusiness = new UserBusiness();
        }

        [HttpPost, Route("login")]
        public IHttpActionResult Login([FromBody] Credentials credentials)
        {
            var user = this._userBusiness.GetByName(credentials.UserName);
            if (user == null)
            {
                return BadRequest("Usuario invalido");
            }
            if (!user.LastName.Equals(credentials.Password))
            {
                return BadRequest("Credenciales incorrectas");
            }
            return Ok(user);
        }
    }
}
