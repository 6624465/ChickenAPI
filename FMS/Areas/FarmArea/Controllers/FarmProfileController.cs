using FMS.Contract.Farm;
using FMS.Contract.ViewModel;
using FMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FMS.Areas.FarmArea.Controllers
{
    [RoutePrefix("api/FarmProfile")]
    public class FarmProfileController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(FarmProfileVM farmProfileVm)
        {
            try
            {
                FarmProfile farmProfile = new FarmProfile();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (farmProfileVm.FarmID == 0)
                    {
                        farmProfile = new FarmProfile();
                    }
                    else
                    {
                        farmProfile = uow.FarmProfileRepository.Get(x => x.FarmID == farmProfileVm.FarmID);
                    }

                    farmProfile.FarmID = farmProfileVm.FarmID;
                    farmProfile.FarmName = farmProfileVm.FarmName;
                    farmProfile.FarmAddress = farmProfileVm.FarmAddress;
                    farmProfile.PhoneNo = farmProfileVm.PhoneNo;
                    farmProfile.MobileNo = farmProfileVm.MobileNo;
                    farmProfile.LineID = farmProfileVm.LineID;
                    farmProfile.SocialPage = farmProfileVm.SocialPage;
                    farmProfile.WebSite = farmProfileVm.WebSite;
                    farmProfile.AboutUs = farmProfileVm.AboutUs;

                    var myfilename = string.Format(@"{0}{1}", Guid.NewGuid(), ".jpeg");
                    if (farmProfileVm.FileName != null && farmProfileVm.FileName.Length > 0)
                    {
                        farmProfile.FarmLogo = myfilename;
                    }

                    uow.FarmProfileRepository.Save(farmProfile);
                    uow.SaveChanges();

                    if (farmProfileVm.FileName != null && farmProfileVm.FileName.Length > 0)
                    {
                        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/"+ farmProfile.FarmID + "/FarmProfile/" + farmProfile.MobileNo + "/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filepath = path + myfilename;
                        var bytess = Convert.FromBase64String(farmProfileVm.FileName);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }


                    return Ok(farmProfileVm.FarmID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetFarmProfile/{MobileNo}")]
        public IHttpActionResult GetFarmProfile(string MobileNo)
        {
            try
            {
                FarmProfile farmProfile = new FarmProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    farmProfile = uow.FarmProfileRepository.Get(x => x.MobileNo == MobileNo);

                    return Ok(new
                    {
                        farmProfile
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetFarmProfileList/{MobileNo}")]
        public IHttpActionResult GetFarmProfileList(string MobileNo)
        {
            try
            {
                List<FarmProfile> farmProfileList = new List<FarmProfile>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    farmProfileList = uow.FarmProfileRepository.GetAll(x => x.MobileNo == MobileNo).ToList();

                    return Ok(new
                    {
                        farmProfileList
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
