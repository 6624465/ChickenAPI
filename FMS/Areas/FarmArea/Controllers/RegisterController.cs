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

                    if (DateTime.UtcNow > registration.OTPSentDate.Value.AddMinutes(5))
                    {
                        registration.OTPNo = GenerateOTP();
                        registration.IsOTPSent = true;
                        registration.OTPSentDate = DateTime.UtcNow;
                        registration.OTPSentCount = registration.OTPSentCount++;
                        uow.RegistrationRepository.Save(registration);
                        uow.SaveChanges();
                    }

                    new System.Threading.Thread(() =>
                    {
                        SendOTP(MobileNo, registration.OTPNo);
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
                            msg = "Success",
                            registration
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
                    user = uow.UserRepository.Get(x => x.UserID == usr.UserID);
                    if (user != null)
                    {
                        if (user.Password != usr.Password)
                        {
                            msg = "invalid password";
                            return Ok(new
                            {
                                message = msg,
                                user
                            });
                        }
                        else
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
                    }
                    else
                    {
                        registration = uow.RegistrationRepository.Get(x => x.MobileNo == usr.UserID);
                        if (registration != null)
                        {
                            if (registration.Password != usr.Password)
                            {
                                msg = "invalid password";
                            }
                            else
                            {
                                msg = "goto otp";
                            }
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
        [HttpGet]
        [Route("IsMobileNoExists/{MobileNo}")]
        public IHttpActionResult IsMobileNoExists(string MobileNo)
        {
            try
            {
                bool isMobileExist = false;
                Registration registration = new Registration();
                User user = new User();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    user = uow.UserRepository.Get(x => x.UserID == MobileNo);
                    if (user != null)
                    {
                        isMobileExist = true;
                        return Ok(isMobileExist);
                    }
                    else
                    {
                        registration = uow.RegistrationRepository.Get(x => x.MobileNo == MobileNo);
                        if (registration != null)
                        {
                            isMobileExist = true;
                            return Ok(isMobileExist);
                        }
                        else
                        {
                            return Ok(isMobileExist);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("UpdatePassword/{MobileNo}/{Password}")]
        public IHttpActionResult UpdatePassword(string MobileNo, string Password)
        {
            try
            {
                Registration registration = new Registration();
                User user = new User();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    user = uow.UserRepository.Get(x => x.UserID == MobileNo);
                    if (user != null)
                    {
                        user.Password = Password;
                        uow.UserRepository.UpdatePassword(user);
                    }

                    registration = uow.RegistrationRepository.Get(x => x.MobileNo == MobileNo);
                    if (registration != null)
                    {

                        registration.Password = Password;
                        uow.RegistrationRepository.UpdatePassword(registration);
                    }

                    uow.SaveChanges();
                }
                return Ok("Success");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("IsOtpVerify/{MobileNo}/{Otp}")]
        public IHttpActionResult IsOtpVerify(string MobileNo, string Otp)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Registration registration = uow.RegistrationRepository.Get(x => x.MobileNo == MobileNo && x.OTPNo == Otp);
                    if (registration != null)
                    {
                        return Ok("Success");
                    }
                    else
                        return Ok("Invalid Otp Number..");

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
