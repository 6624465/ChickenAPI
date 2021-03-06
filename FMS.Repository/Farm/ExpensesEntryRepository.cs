﻿using FMS.Contract.Farm;
using FMS.EF;
using FMS.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMS.Repository.Farm
{
    public class ExpensesEntryRepository : IExpensesEntryRepository
    {
        private DBContext entities = null;
        public ExpensesEntryRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(ExpensesEntry entity)
        {
            try
            {
                entities.ExpensesEntrys.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(ExpensesEntry entity)
        {
            try
            {
                entities.ExpensesEntrys.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ExpensesEntry entity)
        {
            try
            {
                entities.ExpensesEntrys.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ExpensesEntry Get(Func<ExpensesEntry, bool> predicate)
        {
            try
            {
                return entities.ExpensesEntrys.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<ExpensesEntry> GetAll(Func<ExpensesEntry, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.ExpensesEntrys.Where(predicate).AsQueryable();
                }
                return entities.ExpensesEntrys;
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

        public void Save(ExpensesEntry entity)
        {
            try
            {
                ExpensesEntry expensesEntry = entities.ExpensesEntrys
               .Where(x => x.FarmID == entity.FarmID && x.RecordID == entity.RecordID).FirstOrDefault();

                if (expensesEntry != null)
                {
                    entities.Entry(expensesEntry).State = EntityState.Modified;
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
        // ~ExpensesEntryRepository() {
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