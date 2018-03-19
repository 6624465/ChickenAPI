using FMS.Contract.Farm;
using FMS.EF;
using FMS.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMS.Repository.Farm
{
    public class ExpensesMasterRepository : IExpensesMasterRepository
    {
        private DBContext entities = null;
        public ExpensesMasterRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(ExpensesMaster entity)
        {
            try
            {
                entities.ExpensesMasters.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(ExpensesMaster entity)
        {
            try
            {
                entities.ExpensesMasters.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ExpensesMaster entity)
        {
            try
            {
                entities.ExpensesMasters.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExpensesMaster Get(Func<ExpensesMaster, bool> predicate)
        {
            try
            {
                return entities.ExpensesMasters.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<ExpensesMaster> GetAll(Func<ExpensesMaster, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.ExpensesMasters.Where(predicate).AsQueryable();
                }
                return entities.ExpensesMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetRecordsCount()
        {
            throw new NotImplementedException();
        }

        public void Save(ExpensesMaster entity)
        {
            try
            {
                ExpensesMaster expensesMaster = entities.ExpensesMasters
               .Where(x => x.FramID == entity.FramID && x.ExpensesCode == entity.ExpensesCode).FirstOrDefault();

                if (expensesMaster != null)
                {
                    entities.Entry(expensesMaster).State = EntityState.Modified;
                }
                else
                {
                    Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ExpensesMasterRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}