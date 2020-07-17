using AspNet.Test.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNet.Test.Web.Controllers.Api.v1
{
    [RoutePrefix("api/v1/product")]
    public class ProductController : ApiController
    {
        private readonly ProductBusiness _productsBusiness;

        public ProductController()
        {
            // TODO: Implements Dependency Injection
            this._productsBusiness = new ProductBusiness();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(this._productsBusiness.GetAll());
        }
    }
}
