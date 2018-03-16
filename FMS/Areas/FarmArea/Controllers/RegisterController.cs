using FMS.Contract.Farm;
using FMS.Contract.Security;
using FMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FMS.Areas.FarmArea.Controllers
{
    [RoutePrefix("api/Register")]
    //[Utilities.ChickenAUTHFilter]
    public class RegisterController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(Registration registration)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (registration.ID == 0)
                    {
                        registration.OTPNo = GenerateOTP();
                        registration.IsOTPSent = true;
                        registration.OTPSentDate = DateTime.UtcNow;
                        registration.OTPSentCount = 1;
                    }

                    uow.RegistrationRepository.Save(registration);
                    uow.SaveChanges();

                    SendOTP(registration.MobileNo, registration.OTPNo);

                    return Ok(new
                    {
                        registration
                    });
                }
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
                        registration
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("UpdateOTPStatus")]
        public IHttpActionResult UpdateOTPStatus(Registration reg)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Registration registration = uow.RegistrationRepository.Get(x => x.ID == reg.ID);
                    if (registration != null && registration.OTPNo == reg.OTPNo)
                    {
                        uow.RegistrationRepository.UpdateOTPStatus(reg);
                        uow.SaveChanges();

                        return Ok(new
                        {
                            msg = "Success"
                        });
                    }
                    else
                    {
                        //return InternalServerError();
                        return Ok(new
                        {
                            msg = "Failed"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(User usr)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    User user = uow.UserRepository.Get(x => x.UserID == usr.UserID && x.Password == usr.Password);
                    if (user != null)
                    {
                        FarmProfile farmProfile = uow.FarmProfileRepository.Get(x => x.MobileNo == usr.UserID);
                        if (farmProfile != null)
                        {

                        }

                    }
                    else
                    {
                        Registration registration = uow.RegistrationRepository.Get(x => x.MobileNo == usr.UserID && x.Password == usr.Password);
                        if (registration != null)
                        {

                        }
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


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
