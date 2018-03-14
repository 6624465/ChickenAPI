using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChickenAPI.Utilities;

namespace ChickenAPI.Controllers
{
    [RoutePrefix("api/Registration")]
    [ChickenAUTHFilter]
    public class Registration1Controller : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Product(Product item)
        {
            if (item.MobileNo=="123" && item.Password=="a")
            {
                return Ok(item);
            }            

            return Ok();
        }

        [HttpPost]
        [Route("test")]
        public IHttpActionResult test()
        {
            return Ok();
        }
    }

    public class Product
    {
        public string MobileNo { get; set; }
        public string Password { get; set; }
    }
}
