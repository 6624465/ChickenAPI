using Chicken.Contract.Security;
using Chicken.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChickenAPI.Areas.Security.Controllers
{
    [RoutePrefix("api/Registration")]
    [Utilities.ChickenAUTHFilter]
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Product(Product item)
        {
            if (item.MobileNo == "123" && item.Password == "a")
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

        [HttpGet]
        [Route("test1")]
        public IHttpActionResult test1()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Registration reg = new Registration();
                    reg = uow.RegistrationRepository.Get(x=>x.id==1);
                   
                    return Ok(reg);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class Product
    {
        public string MobileNo { get; set; }
        public string Password { get; set; }
    }

}