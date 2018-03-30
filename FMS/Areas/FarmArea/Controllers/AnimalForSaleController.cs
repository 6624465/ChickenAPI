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
                AnimalForSale animalForSale = new AnimalForSale();

                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (animalForSaleVm.SaleID == -1)
                    {
                        animalForSale = new AnimalForSale();
                        animalForSale.CreatedBy = "ADMIN";
                        animalForSale.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        animalForSale = uow.AnimalForSaleRepository.Get(x => x.AnimalCode == animalForSaleVm.AnimalCode);

                        animalForSale.ModifiedBy = "ADMIN";
                        animalForSale.ModifiedOn = DateTime.UtcNow;
                    }

                    animalForSale.FarmID = FARMID;
                    animalForSale.AnimalCode = animalForSaleVm.AnimalCode;
                    animalForSale.AnimalAge = animalForSaleVm.AnimalAge;
                    animalForSale.Breed = animalForSaleVm.Breed;
                    animalForSale.SireCode = animalForSaleVm.SireCode;
                    animalForSale.BreederCode = animalForSaleVm.BreederCode;
                    animalForSale.Talents = animalForSaleVm.Talents;
                    animalForSale.Age = animalForSaleVm.Age;
                    animalForSale.Weight = animalForSaleVm.Weight;
                    animalForSale.FightingRecord = animalForSaleVm.FightingRecord;
                    animalForSale.IsShowStandardPrice = animalForSaleVm.IsShowStandardPrice;
                    animalForSale.IsActive = animalForSaleVm.IsActive;

                    var myfilename = string.Format(@"{0}{1}", Guid.NewGuid(), ".jpeg");
                    if (animalForSaleVm.FileName != null && animalForSaleVm.FileName.Length > 0)
                    {
                        animalForSale.AnimalPhoto = myfilename;
                    }

                    uow.AnimalForSaleRepository.Save(animalForSale);
                    uow.SaveChanges();

                    if (animalForSaleVm.FileName != null && animalForSaleVm.FileName.Length > 0)
                    {
                        string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Uploads/" + animalForSale.FarmID + "/AnimalForSale/" + animalForSale.SaleID + "/");
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

                    var animalProfile = uow.AnimalProfileRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        animalForSale,
                        animalProfile
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
