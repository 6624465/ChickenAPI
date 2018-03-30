using FMS.Contract.Farm;
using FMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
                VaccineEntry vaccinedtl = new VaccineEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (vaccineEntry.RecordID == -1)
                    {
                        vaccinedtl = vaccineEntry;

                        vaccinedtl.CreatedBy = "ADMIN";
                        vaccinedtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        vaccinedtl = uow.VaccineEntryRepository.Get(x => x.RecordID == vaccineEntry.RecordID);

                        vaccinedtl.AnimalCode = vaccineEntry.AnimalCode;
                        vaccinedtl.AnimalAge = vaccineEntry.AnimalAge;
                        vaccinedtl.VaccineType = vaccineEntry.VaccineType;
                        vaccinedtl.VaccineName = vaccineEntry.VaccineName;
                        vaccinedtl.VaccineCompany = vaccineEntry.VaccineCompany;
                        vaccinedtl.Remarks = vaccineEntry.Remarks;
                        vaccinedtl.IsDeleted = vaccineEntry.IsDeleted;

                        vaccinedtl.ModifiedBy = "ADMIN";
                        vaccinedtl.ModifiedOn = DateTime.UtcNow;
                    }

                    vaccinedtl.FarmID = FARMID;


                    uow.VaccineEntryRepository.Save(vaccinedtl);
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
                    vaccineEntry =  uow.VaccineEntryRepository.Get(x => x.RecordID == RecordID && x.FarmID == FARMID);

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
