using FMS.Contract.Config;
using FMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FMS.Areas.ConfigArea.Controllers
{
    [RoutePrefix("api/Lookup")]
    public class LookupController : ApiBase
    {
        [HttpGet]
        [Route("GetLookupList/{LookupCategory}")]
        public IHttpActionResult GetLookupList(string LookupCategory)
        {
            try
            {
                List<Lookup> lookupList = new List<Lookup>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    lookupList = uow.LookupRepository.GetAll(x => x.LookupCategory == LookupCategory).ToList();

                    return Ok(new
                    {
                        lookupList
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
