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
    [RoutePrefix("api/VaccineMaster")]
    public class VaccineMasterController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(VaccineMasterVM vaccineMasterVm)
        {
            try
            {
                VaccineMaster vaccineMaster = new VaccineMaster();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (vaccineMasterVm.VaccineCode == -1)
                    {
                        vaccineMaster = new VaccineMaster();
                        vaccineMaster.CreatedBy = "ADMIN";
                        vaccineMaster.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        vaccineMaster = uow.VaccineMasterRepository.Get(x => x.VaccineCode == vaccineMasterVm.VaccineCode);

                        vaccineMaster.ModifiedBy = "ADMIN";
                        vaccineMaster.ModifiedOn = DateTime.UtcNow;
                    }

                    vaccineMaster.FarmID = FARMID;
                    vaccineMaster.VaccineName = vaccineMasterVm.VaccineName;
                    vaccineMaster.VaccineType = vaccineMasterVm.VaccineType;
                    vaccineMaster.VaccineCompany = vaccineMasterVm.VaccineCompany;
                    vaccineMaster.PurchaseDate = vaccineMasterVm.PurchaseDate;
                    vaccineMaster.ExpiryDate = vaccineMasterVm.ExpiryDate;
                    vaccineMaster.BatchNo = vaccineMasterVm.BatchNo;
                    vaccineMaster.Supplier = vaccineMasterVm.Supplier;
                    vaccineMaster.Quantity = vaccineMasterVm.Quantity;
                    vaccineMaster.IsDeleted = vaccineMasterVm.IsDeleted;

                    var myfilename = string.Format(@"{0}{1}", Guid.NewGuid(), ".jpeg");
                    if (vaccineMasterVm.FileName != null && vaccineMasterVm.FileName.Length > 0)
                    {
                        vaccineMaster.Photo = myfilename;
                    }

                    uow.VaccineMasterRepository.Save(vaccineMaster);
                    uow.SaveChanges();

                    if (vaccineMasterVm.FileName != null && vaccineMasterVm.FileName.Length > 0)
                    {
                        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/" + vaccineMaster.FarmID + "/VaccineMaster/" + vaccineMaster.VaccineCode + "/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filepath = path + myfilename;
                        var bytess = Convert.FromBase64String(vaccineMasterVm.FileName);
                        using (var imageFile = new FileStream(filepath, FileMode.Create))
                        {
                            imageFile.Write(bytess, 0, bytess.Length);
                            imageFile.Flush();
                        }
                    }


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
        [Route("GetVaccineMaster/{VaccineCode}")]
        public IHttpActionResult GetVaccineMaster(int VaccineCode)
        {
            try
            {
                VaccineMaster vaccineMaster = new VaccineMaster();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    vaccineMaster = uow.VaccineMasterRepository.Get(x => x.VaccineCode == VaccineCode && x.FarmID == FARMID);

                    vaccineMaster = vaccineMaster == null ? new VaccineMaster { VaccineCode = -1 } : vaccineMaster;
                    return Ok(new
                    {
                        vaccineMaster
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetVaccineMasterList")]
        public IHttpActionResult GetVaccineMasterList()
        {
            try
            {
                List<VaccineMaster> vaccineMasterList = new List<VaccineMaster>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    vaccineMasterList = uow.VaccineMasterRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        vaccineMasterList
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
