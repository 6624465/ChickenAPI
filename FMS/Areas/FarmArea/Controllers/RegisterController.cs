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

                    new System.Threading.Thread(() =>
                    {
                        SendOTP(registration.MobileNo, registration.OTPNo);
                    }).Start();

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
        [Route("GetRegistration/{MobileNo}")]
        public IHttpActionResult GetRegistration(string MobileNo)
        {
            try
            {
                Registration registration = new Registration();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    registration = uow.RegistrationRepository.Get(x => x.MobileNo == MobileNo);

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
        [Route("ResendOTP/{MobileNo}")]
        public IHttpActionResult ResendOTP(string MobileNo)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Registration registration = uow.RegistrationRepository.Get(x => x.MobileNo == MobileNo);
                    registration.OTPNo = GenerateOTP();
                    registration.IsOTPSent = true;
                    registration.OTPSentDate = DateTime.UtcNow;
                    registration.OTPSentCount = registration.OTPSentCount++;
                    uow.RegistrationRepository.Save(registration);
                    uow.SaveChanges();

                    new System.Threading.Thread(() =>
                    {
                        SendOTP(MobileNo, registration.OTPNo);
                    }).Start();

                    return Ok(new
                    {

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

                        //Insert User Information
                        User user = new User();
                        user.CompanyCode = 1;
                        user.UserID = registration.MobileNo;
                        user.UserName = registration.FullName;
                        user.Password = registration.Password;
                        user.UserGroup = 0;
                        user.UserDesignation = 0;
                        user.EmployeeID = "";
                        user.ICNo = "";
                        user.EmailID = registration.Email;
                        user.ContactNo = registration.MobileNo;
                        user.IsActive = true;
                        user.IsAllowLogOn = true;
                        user.IsOperational = false;
                        user.CreatedBy = registration.Email;
                        user.CreatedOn = DateTime.UtcNow;
                        user.BranchID = 0;

                        uow.UserRepository.Save(user);

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
                User user = new User();
                Registration registration = new Registration();
                FarmProfile farmProfile = new FarmProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string msg = "";
                    user = uow.UserRepository.Get(x => x.UserID == usr.UserID && x.Password == usr.Password);
                    if (user != null)
                    {
                        farmProfile = uow.FarmProfileRepository.Get(x => x.MobileNo == usr.UserID);
                        if (farmProfile != null)
                        {
                            msg = "goto menu";

                            return Ok(new
                            {
                                message = msg,
                                user
                            });
                        }
                        else
                        {
                            msg = "goto farm";
                            return Ok(new
                            {
                                message = msg,
                                registration,
                                user
                            });
                        }
                    }
                    else
                    {
                        registration = uow.RegistrationRepository.Get(x => x.MobileNo == usr.UserID && x.Password == usr.Password);
                        if (registration != null)
                        {
                            msg = "goto otp";
                        }
                        else
                        {
                            msg = "goto registration";
                        }

                        return Ok(new
                        {
                            message = msg,
                            registration,
                            user
                        });
                    }
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
