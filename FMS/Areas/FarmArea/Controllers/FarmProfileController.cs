using FMS.Contract.Farm;
using FMS.Repository;
using System;
using System.Collections.Generic;
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
        public IHttpActionResult Save(FarmProfile farmProfile)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (farmProfile.FarmID == 0)
                    {
                    }

                    uow.FarmProfileRepository.Save(farmProfile);
                    uow.SaveChanges();

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

        [HttpGet]
        [Route("GetFarmProfile/{FarmID}")]
        public IHttpActionResult GetFarmProfile(Int32 FarmID)
        {
            try
            {
                FarmProfile farmProfile = new FarmProfile();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    farmProfile = uow.FarmProfileRepository.Get(x => x.FarmID == FarmID);

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
