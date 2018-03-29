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
    [RoutePrefix("api/StandardPrice")]
    public class StandardPriceController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(StandardPrice standardPrice)
        {
            try
            {
                StandardPrice standardPricedtl = new StandardPrice();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (standardPrice.StandardPriceId == -1)
                    {
                        standardPricedtl = standardPrice;

                        standardPricedtl.CreatedBy = "ADMIN";
                        standardPricedtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        standardPricedtl = uow.StandardPriceRepository.Get(x => x.StandardPriceId == standardPrice.StandardPriceId);

                        standardPricedtl.SireCode = standardPrice.SireCode;
                        standardPricedtl.BreederCode = standardPrice.BreederCode;
                        standardPricedtl.Price = standardPrice.Price;
                        standardPricedtl.CurrencyCode = standardPrice.CurrencyCode;
                        standardPricedtl.ExRate = standardPrice.ExRate;
                        standardPricedtl.LocalPrice = standardPrice.LocalPrice;
                        standardPricedtl.IsActive = standardPrice.IsActive;

                        standardPricedtl.ModifiedBy = "ADMIN";
                        standardPricedtl.ModifiedOn = DateTime.UtcNow;
                    }

                    standardPricedtl.FarmID = FARMID;


                    uow.StandardPriceRepository.Save(standardPricedtl);
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
        [Route("GetStandardPrice/{StandardPriceId}")]
        public IHttpActionResult GetStandardPrice(int StandardPriceId)
        {
            try
            {
                StandardPrice standardPrice = new StandardPrice();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    standardPrice = uow.StandardPriceRepository.Get(x => x.StandardPriceId == StandardPriceId && x.FarmID == FARMID);

                    standardPrice = standardPrice == null ? new StandardPrice { StandardPriceId = -1 } : standardPrice;

                    var currencyList = uow.LookupRepository.GetAll(x => x.LookupCategory == Utility.CONFIG_CURRENCY).ToList();

                    return Ok(new
                    {
                        standardPrice,
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
        [Route("GetStandardPriceList")]
        public IHttpActionResult GetStandardPriceList()
        {
            try
            {
                List<StandardPrice> standardPriceList = new List<StandardPrice>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    standardPriceList = uow.StandardPriceRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        standardPriceList
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
