using Chicken.Contract.Farm;
using Chicken.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChickenAPI.Areas.Farm.Controllers
{
    [RoutePrefix("api/Registration")]
    //[Utilities.ChickenAUTHFilter]
    public class RegistrationController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(Registration registration)
        {
            try
            {
                //registration.OTPSentDate = DateTime.UtcNow;
                if (registration.ID == 0)
                    registration.OTPNo = GenerateOTP();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    //uow.RegistrationRepository.Save(registration);
                    //uow.SaveChanges();
                    SendOTP(registration.MobileNo, registration.OTPNo);

                }
                return Ok(new
                {
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetRegistration/{ID}")]
        public IHttpActionResult GetRegistration(Int32 ID)
        {
            try
            {
                Registration registration = new Registration();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    registration = uow.RegistrationRepository.Get(x => x.ID == ID);

                    return Ok(new
                    {
                        reg = registration
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpPost]
        //[Route("Login")]
        //public IHttpActionResult Product(Product item)
        //{
        //    if (item.MobileNo == "123" && item.Password == "a")
        //    {
        //        return Ok(item);
        //    }

        //    return Ok();
        //}
        //[HttpPost]
        //[Route("test")]
        //public IHttpActionResult test()
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //[Route("test1")]
        //public IHttpActionResult test1()
        //{
        //    try
        //    {
        //        using (UnitOfWork uow = new UnitOfWork())
        //        {
        //            Registration reg = new Registration();
        //            reg = uow.RegistrationRepository.Get(x=>x.ID==1);

        //            return Ok(reg);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}