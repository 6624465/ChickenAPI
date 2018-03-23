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
    [RoutePrefix("api/VaccineSchedule")]
    public class VaccineScheduleController : ApiBase
    {
        //[HttpPost]
        //[Route("save")]
        //public IHttpActionResult Save(VaccineSchedule vaccineSchedule)
        //{
        //    try
        //    {
        //        VaccineSchedule vaccineScheduledtl = new VaccineSchedule();
        //        using (UnitOfWork uow = new UnitOfWork())
        //        {
        //            if (vaccineSchedule.RecordID == -1)
        //            {
        //                vaccineScheduledtl = vaccineSchedule;

        //                vaccineScheduledtl.CreatedBy = "ADMIN";
        //                vaccineScheduledtl.CreatedOn = DateTime.UtcNow;
        //            }
        //            else
        //            {
        //                vaccineScheduledtl = uow.VaccineScheduleRepository.Get(x => x.RecordID == vaccineSchedule.RecordID);

        //                vaccineScheduledtl.AnimalCode = vaccineSchedule.AnimalCode;
        //                vaccineScheduledtl.AnimalAge = vaccineSchedule.AnimalAge;
        //                vaccineScheduledtl.VaccineType = vaccineSchedule.VaccineType;
        //                vaccineScheduledtl.VaccineName = vaccineSchedule.VaccineName;
        //                vaccineScheduledtl.VaccineCompany = vaccineSchedule.VaccineCompany;
        //                vaccineScheduledtl.Remarks = vaccineSchedule.Remarks;
        //                vaccineScheduledtl.IsDeleted = vaccineSchedule.IsDeleted;

        //                vaccineScheduledtl.ModifiedBy = "ADMIN";
        //                vaccineScheduledtl.ModifiedOn = DateTime.UtcNow;
        //            }

        //            vaccineScheduledtl.FarmID = FARMID;


        //            uow.VaccineScheduleRepository.Save(vaccineScheduledtl);
        //            uow.SaveChanges();

        //            return Ok(new
        //            {
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpGet]
        //[Route("GetVaccineSchedule/{RecordID}")]
        //public IHttpActionResult GetVaccineSchedule(int RecordID)
        //{
        //    try
        //    {
        //        VaccineSchedule vaccineSchedule = new VaccineSchedule();
        //        using (UnitOfWork uow = new UnitOfWork())
        //        {
        //            vaccineSchedule = uow.VaccineScheduleRepository.Get(x => x.VaccineCode == VaccineCode && x.FarmID == FARMID);

        //            vaccineSchedule = vaccineSchedule == null ? new VaccineSchedule { RecordID = -1 } : vaccineSchedule;

        //            var lstVaccineMaster = uow.VaccineMasterRepository.GetAll(x => x.FarmID == FARMID && x.IsDeleted != false).ToList();
        //            var lstAnimalProfile = uow.AnimalProfileRepository.GetAll(x => x.FarmID == FARMID).ToList();

        //            return Ok(new
        //            {
        //                vaccineSchedule,
        //                lstVaccineMaster,
        //                lstAnimalProfile
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        //[HttpGet]
        //[Route("GetVaccineScheduleList")]
        //public IHttpActionResult GetVaccineScheduleList()
//        {
//            try
//            {
//                List<VaccineSchedule> vaccineScheduleList = new List<VaccineSchedule>();
//                using (UnitOfWork uow = new UnitOfWork())
//                {
//                    vaccineScheduleList = uow.VaccineScheduleRepository.GetAll(x => x.FarmID == FARMID).ToList();

//                    return Ok(new
//                    {
//                        vaccineScheduleList
//});
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
    }
}
