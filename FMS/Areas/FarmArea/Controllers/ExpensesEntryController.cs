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
    [RoutePrefix("api/ExpensesEntry")]
    public class ExpensesEntryController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(ExpensesEntry expensesEntry)
        {
            try
            {
                ExpensesEntry expensesEntrydtl = new ExpensesEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (expensesEntry.RecordID == -1)
                    {
                        expensesEntrydtl = expensesEntry;

                        expensesEntrydtl.CreatedBy = "ADMIN";
                        expensesEntrydtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        expensesEntrydtl = uow.ExpensesEntryRepository.Get(x => x.RecordID == expensesEntry.RecordID);

                        expensesEntrydtl.ExpensesCode = expensesEntry.ExpensesCode;
                        expensesEntrydtl.VendorName = expensesEntry.VendorName;
                        expensesEntrydtl.VendorAddress = expensesEntry.VendorAddress;
                        expensesEntrydtl.Amount = expensesEntry.Amount;
                        expensesEntrydtl.Remarks = expensesEntry.Remarks;
                        expensesEntrydtl.IsDeleted = expensesEntry.IsDeleted;

                        expensesEntrydtl.ModifiedBy = "ADMIN";
                        expensesEntrydtl.ModifiedOn = DateTime.UtcNow;
                    }
                    expensesEntrydtl.FarmID = FARMID;

                    uow.ExpensesEntryRepository.Save(expensesEntrydtl);
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
        [Route("GetExpensesEntry/{RecordID}")]
        public IHttpActionResult GetExpensesEntry(int RecordID)
        {
            try
            {
                ExpensesEntry expensesEntry = new ExpensesEntry();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    expensesEntry = uow.ExpensesEntryRepository.Get(x => x.RecordID == RecordID && x.FarmID == FARMID);

                    expensesEntry = expensesEntry == null ? new ExpensesEntry { RecordID = -1 } : expensesEntry;
                    var lstExpensesMaster = uow.ExpensesMasterRepository.GetAll(x => x.FarmID == FARMID && x.IsDeleted != false).ToList();

                    return Ok(new
                    {
                        expensesEntry,
                        lstExpensesMaster
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetExpensesEntryList")]
        public IHttpActionResult GetExpensesEntryList()
        {
            try
            {
                List<ExpensesEntry> expensesEntryList = new List<ExpensesEntry>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    expensesEntryList = uow.ExpensesEntryRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        expensesEntryList
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
