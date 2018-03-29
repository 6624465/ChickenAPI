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
    [RoutePrefix("api/MedicineMaster")]
    public class MedicineMasterController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(MedicineMaster medicineMasterVm)
        {
            try
            {
                MedicineMaster medicineMasterDtl = new MedicineMaster();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (medicineMasterVm.MedicineCode == -1)
                    {
                        medicineMasterDtl = new MedicineMaster();
                        medicineMasterDtl.CreatedBy = "ADMIN";
                        medicineMasterDtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        medicineMasterDtl = uow.MedicineMasterRepository.Get(x => x.MedicineCode == medicineMasterVm.MedicineCode);

                        medicineMasterDtl.ModifiedBy = "ADMIN";
                        medicineMasterDtl.ModifiedOn = DateTime.UtcNow;
                    }

                    medicineMasterDtl.FarmID = FARMID;
                    medicineMasterDtl.MedicineName = medicineMasterVm.MedicineName;
                    medicineMasterDtl.MedicineType = medicineMasterVm.MedicineType;
                    medicineMasterDtl.MedicineCompany = medicineMasterVm.MedicineCompany;
                    medicineMasterDtl.PurchaseDate = medicineMasterVm.PurchaseDate;
                    medicineMasterDtl.ExpiryDate = medicineMasterVm.ExpiryDate;
                    medicineMasterDtl.BatchNo = medicineMasterVm.BatchNo;
                    medicineMasterDtl.Supplier = medicineMasterVm.Supplier;
                    medicineMasterDtl.Quantity = medicineMasterVm.Quantity;
                    medicineMasterDtl.IsDeleted = medicineMasterVm.IsDeleted;

                    //var myfilename = string.Format(@"{0}{1}", Guid.NewGuid(), ".jpeg");
                    //if (medicineMasterVm.FileName != null && medicineMasterVm.FileName.Length > 0)
                    //{
                    //    medicineMasterDtl.Photo = myfilename;
                    //}

                    uow.MedicineMasterRepository.Save(medicineMasterDtl);
                    uow.SaveChanges();

                    //if (medicineMasterVm.FileName != null && medicineMasterVm.FileName.Length > 0)
                    //{
                    //    string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/" + medicineMaster.FarmID + "/MedicineMaster/" + medicineMaster.MedicineCode + "/");
                    //    if (!Directory.Exists(path))
                    //    {
                    //        Directory.CreateDirectory(path);
                    //    }
                    //    string filepath = path + myfilename;
                    //    var bytess = Convert.FromBase64String(medicineMasterVm.FileName);
                    //    using (var imageFile = new FileStream(filepath, FileMode.Create))
                    //    {
                    //        imageFile.Write(bytess, 0, bytess.Length);
                    //        imageFile.Flush();
                    //    }
                    //}


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
        [Route("GetMedicineMaster/{MedicineCode}")]
        public IHttpActionResult GetMedicineMaster(int MedicineCode)
        {
            try
            {
                MedicineMaster medicineMaster = new MedicineMaster();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    medicineMaster = uow.MedicineMasterRepository.Get(x => x.MedicineCode == MedicineCode && x.FarmID == FARMID);

                    medicineMaster = medicineMaster == null ? new MedicineMaster { MedicineCode = -1 } : medicineMaster;
                    return Ok(new
                    {
                        medicineMaster
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetMedicineMasterList")]
        public IHttpActionResult GetMedicineMasterList()
        {
            try
            {
                List<MedicineMaster> medicineMasterList = new List<MedicineMaster>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    medicineMasterList = uow.MedicineMasterRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        medicineMasterList
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
