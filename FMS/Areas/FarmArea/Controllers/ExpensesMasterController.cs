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
    [RoutePrefix("api/ExpensesMaster")]
    public class ExpensesMasterController : ApiBase
    {
        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save(ExpensesMaster expensesMaster)
        {
            try
            {
                ExpensesMaster expensesMasterdtl = new ExpensesMaster();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (expensesMaster.ExpensesID == -1)
                    {
                        expensesMasterdtl = expensesMaster;

                        expensesMasterdtl.CreatedBy = "ADMIN";
                        expensesMasterdtl.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        expensesMasterdtl = uow.ExpensesMasterRepository.Get(x => x.ExpensesID == expensesMaster.ExpensesID);

                        expensesMasterdtl.ExpensesCode = expensesMaster.ExpensesCode;
                        expensesMasterdtl.ExpensesName = expensesMaster.ExpensesName;
                        expensesMasterdtl.ExpensesType = expensesMaster.ExpensesType;
                        expensesMasterdtl.IsDeleted = expensesMaster.IsDeleted;

                        expensesMasterdtl.ModifiedBy = "ADMIN";
                        expensesMasterdtl.ModifiedOn = DateTime.UtcNow;
                    }

                    expensesMasterdtl.FarmID = FARMID;


                    uow.ExpensesMasterRepository.Save(expensesMasterdtl);
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
        [Route("GetExpensesMaster/{ExpensesID}")]
        public IHttpActionResult GetExpensesMaster(int ExpensesID)
        {
            try
            {
                ExpensesMaster expensesMaster = new ExpensesMaster();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    expensesMaster = uow.ExpensesMasterRepository.Get(x => x.ExpensesID == ExpensesID && x.FarmID == FARMID);

                    expensesMaster = expensesMaster == null ? new ExpensesMaster { ExpensesID = -1 } : expensesMaster;
                    
                    return Ok(new
                    {
                        expensesMaster
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetExpensesMasterList")]
        public IHttpActionResult GetExpensesMasterList()
        {
            try
            {
                List<ExpensesMaster> expensesMasterList = new List<ExpensesMaster>();
                using (UnitOfWork uow = new UnitOfWork())
                {
                    expensesMasterList = uow.ExpensesMasterRepository.GetAll(x => x.FarmID == FARMID).ToList();

                    return Ok(new
                    {
                        expensesMasterList
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
