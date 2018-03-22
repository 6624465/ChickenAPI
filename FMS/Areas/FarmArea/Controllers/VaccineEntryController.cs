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
    [RoutePrefix("api/VaccineEntry")]
    public class VaccineEntryController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(VaccineEntry vaccineEntry)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (vaccineEntry.RecordID == -1)
                    {
                        //vaccineEntry = new VaccineEntry();
                        vaccineEntry.CreatedBy = "ADMIN";
                        vaccineEntry.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        vaccineEntry = uow.VaccineEntryRepository.Get(x => x.RecordID == vaccineEntry.RecordID);

                        vaccineEntry.ModifiedBy = "ADMIN";
                        vaccineEntry.ModifiedOn = DateTime.UtcNow;
                    }

                    vaccineEntry.FarmID = FARMID;


                    uow.VaccineEntryRepository.Save(vaccineEntry);
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
        [Route("GetVaccineEntry/{RecordID}")]
        public IHttpActionResult GetVaccineEntry(int RecordID)
        {
            try
            {
                VaccineEntry vaccineEntry = new VaccineEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    vaccineEntry = uow.VaccineEntryRepository.Get(x => x.RecordID == RecordID && x.FarmID == FARMID);

                    vaccineEntry = vaccineEntry == null ? new VaccineEntry { RecordID = -1 } : vaccineEntry;

                    var lstVaccineMaster = uow.VaccineMasterRepository.GetAll(x => x.FarmID == FARMID && x.IsDeleted != false).ToList();
                    var lstAnimalProfile = uow.AnimalProfileRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        vaccineEntry,
                        lstVaccineMaster,
                        lstAnimalProfile
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetVaccineEntryList")]
        public IHttpActionResult GetVaccineEntryList()
        {
            try
            {
                List<VaccineEntry> vaccineEntryList = new List<VaccineEntry>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    vaccineEntryList = uow.VaccineEntryRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        vaccineEntryList
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
