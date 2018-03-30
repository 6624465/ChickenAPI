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
    [RoutePrefix("api/AnimalSaleEntry")]
    public class AnimalSaleEntryController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(AnimalSaleEntry animalSaleEntry)
        {
            try
            {
                AnimalSaleEntry animalSaleEntrydtl = new AnimalSaleEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (animalSaleEntry.SaleEntryID == -1)
                    {
                        animalSaleEntrydtl = animalSaleEntry;

                        animalSaleEntrydtl.CreatedBy = "ADMIN";
                        animalSaleEntrydtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        animalSaleEntrydtl = uow.AnimalSaleEntryRepository.Get(x => x.SaleEntryID == animalSaleEntry.SaleEntryID);

                        animalSaleEntrydtl.AnimalCode = animalSaleEntry.AnimalCode;
                        animalSaleEntrydtl.AnimalStatus = animalSaleEntry.AnimalStatus;
                        animalSaleEntrydtl.BuyerName = animalSaleEntry.BuyerName;
                        animalSaleEntrydtl.BuyerAddress = animalSaleEntry.BuyerAddress;
                        animalSaleEntrydtl.BuyerPhoneNo = animalSaleEntry.BuyerPhoneNo;
                        animalSaleEntrydtl.BuyerMobileNo = animalSaleEntry.BuyerMobileNo;
                        animalSaleEntrydtl.Price = animalSaleEntry.Price;
                        animalSaleEntrydtl.Discount = animalSaleEntry.Discount;
                        animalSaleEntrydtl.TotalPrice = animalSaleEntry.TotalPrice;
                        animalSaleEntrydtl.IsActive = animalSaleEntry.IsActive;

                        animalSaleEntrydtl.ModifiedBy = "ADMIN";
                        animalSaleEntrydtl.ModifiedOn = DateTime.UtcNow;
                    }

                    animalSaleEntrydtl.FarmID = FARMID;


                    uow.AnimalSaleEntryRepository.Save(animalSaleEntrydtl);
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
        [Route("GetAnimalSaleEntry/{AnimalSaleEntryId}")]
        public IHttpActionResult GetAnimalSaleEntry(int AnimalSaleEntryId)
        {
            try
            {
                AnimalSaleEntry animalSaleEntry = new AnimalSaleEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalSaleEntry = uow.AnimalSaleEntryRepository.Get(x => x.SaleEntryID == AnimalSaleEntryId && x.FarmID == FARMID);

                    animalSaleEntry = animalSaleEntry == null ? new AnimalSaleEntry { SaleEntryID = -1 } : animalSaleEntry;

                    var animalProfile = uow.AnimalProfileRepository.GetAll(x => x.FarmID ==FARMID).ToList();

                    return Ok(new
                    {
                        animalSaleEntry,
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
        [Route("GetAnimalSaleEntryList")]
        public IHttpActionResult GetAnimalSaleEntryList()
        {
            try
            {
                List<AnimalSaleEntry> animalSaleEntryList = new List<AnimalSaleEntry>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    animalSaleEntryList = uow.AnimalSaleEntryRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        animalSaleEntryList
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
