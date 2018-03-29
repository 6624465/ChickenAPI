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
    [RoutePrefix("api/AnimalForSale")]
    public class AnimalForSaleController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(AnimalForSaleVM animalForSaleVm)
        {
            try
            {
                AnimalForSale animalProfile = new AnimalForSale();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (animalForSaleVm.SaleID == -1)
                    {
                        animalProfile = new AnimalForSale();
                        animalProfile.CreatedBy = "ADMIN";
                        animalProfile.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        animalProfile = uow.AnimalForSaleRepository.Get(x => x.AnimalCode == animalForSaleVm.AnimalCode);

                        animalProfile.ModifiedBy = "ADMIN";
                        animalProfile.ModifiedOn = DateTime.UtcNow;
                    }

                    animalProfile.FarmID = FARMID;
                    animalProfile.AnimalCode = animalForSaleVm.AnimalCode;
                    animalProfile.AnimalAge = animalForSaleVm.AnimalAge;
                    animalProfile.Breed = animalForSaleVm.Breed;
                    animalProfile.SireCode = animalForSaleVm.SireCode;
                    animalProfile.BreederCode = animalForSaleVm.BreederCode;
                    animalProfile.Talents = animalForSaleVm.Talents;
                    animalProfile.Age = animalForSaleVm.Age;
                    animalProfile.Weight = animalForSaleVm.Weight;
                    animalProfile.FightingRecord = animalForSaleVm.FightingRecord;
                    animalProfile.IsShowStandardPrice = animalForSaleVm.IsShowStandardPrice;
                    animalProfile.IsActive = animalForSaleVm.IsActive;

                    var myfilename = string.Format(@"{0}{1}", Guid.NewGuid(), ".jpeg");
                    if (animalForSaleVm.FileName != null && animalForSaleVm.FileName.Length > 0)
                    {
                        animalProfile.AnimalPhoto = myfilename;
                    }

                    uow.AnimalForSaleRepository.Save(animalProfile);
                    uow.SaveChanges();

                    if (animalForSaleVm.FileName != null && animalForSaleVm.FileName.Length > 0)
                    {
                        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/" + animalProfile.FarmID + "/AnimalForSale/" + animalProfile.AnimalCode + "/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filepath = path + myfilename;
                        var bytess = Convert.FromBase64String(animalForSaleVm.FileName);
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
        [Route("GetAnimalForSale/{SaleID}")]
        public IHttpActionResult GetAnimalForSale(int SaleID)
        {
            try
            {
                AnimalForSale animalForSale = new AnimalForSale();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalForSale = uow.AnimalForSaleRepository.Get(x => x.SaleID == SaleID && x.FarmID == FARMID);

                    animalForSale = animalForSale == null ? new AnimalForSale { SaleID = -1 } : animalForSale;

                    var currencyList = uow.LookupRepository.GetAll(x => x.LookupCategory == Utility.CONFIG_CURRENCY).ToList();

                    return Ok(new
                    {
                        animalForSale,
                        currencyList
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetAnimalForSaleList")]
        public IHttpActionResult GetAnimalForSaleList()
        {
            try
            {
                List<AnimalForSale> animalForSaleList = new List<AnimalForSale>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalForSaleList = uow.AnimalForSaleRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        animalForSaleList
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
