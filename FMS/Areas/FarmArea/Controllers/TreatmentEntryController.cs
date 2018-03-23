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
    [RoutePrefix("api/TreatmentEntry")]
    public class TreatmentEntryController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(TreatmentEntry treatmentEntry)
        {
            try
            {
                TreatmentEntry treatmentdtl = new TreatmentEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (treatmentEntry.RecordID == -1)
                    {
                        treatmentdtl = treatmentEntry;

                        treatmentdtl.CreatedBy = "ADMIN";
                        treatmentdtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        treatmentdtl = uow.TreatmentEntryRepository.Get(x => x.RecordID == treatmentEntry.RecordID);

                        treatmentdtl.AnimalCode = treatmentEntry.AnimalCode;
                        treatmentdtl.MedicineName = treatmentEntry.MedicineName;
                        treatmentdtl.Reason = treatmentEntry.Reason;
                        treatmentdtl.StartDate = treatmentEntry.StartDate;
                        treatmentdtl.EndDate = treatmentEntry.EndDate;
                        treatmentdtl.Dosage = treatmentEntry.Dosage;
                        treatmentdtl.Remarks = treatmentEntry.Remarks;
                        treatmentdtl.IsDeleted = treatmentEntry.IsDeleted;

                        treatmentdtl.ModifiedBy = "ADMIN";
                        treatmentdtl.ModifiedOn = DateTime.UtcNow;
                    }

                    treatmentdtl.FarmID = FARMID;


                    uow.TreatmentEntryRepository.Save(treatmentdtl);
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
        [Route("GetTreatmentEntry/{RecordID}")]
        public IHttpActionResult GetTreatmentEntry(int RecordID)
        {
            try
            {
                TreatmentEntry TreatmentEntry = new TreatmentEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    TreatmentEntry = uow.TreatmentEntryRepository.Get(x => x.RecordID == RecordID && x.FarmID == FARMID);

                    TreatmentEntry = TreatmentEntry == null ? new TreatmentEntry { RecordID = -1 } : TreatmentEntry;

                    var lstVaccineMaster = uow.VaccineMasterRepository.GetAll(x => x.FarmID == FARMID && x.IsDeleted != false).ToList();
                    var lstAnimalProfile = uow.AnimalProfileRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        TreatmentEntry,
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
        [Route("GetTreatmentEntryList")]
        public IHttpActionResult GetTreatmentEntryList()
        {
            try
            {
                List<TreatmentEntry> TreatmentEntryList = new List<TreatmentEntry>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    TreatmentEntryList = uow.TreatmentEntryRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        TreatmentEntryList
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
