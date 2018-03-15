﻿using Chicken.Contract.Farm;
using Chicken.EF;
using Chicken.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.Repository.Farm
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
            throw new NotImplementedException();
        }

        public void Attach(ExpensesMaster entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExpensesMaster entity)
        {
            throw new NotImplementedException();
        }

        public ExpensesMaster Get(Func<ExpensesMaster, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExpensesMaster> GetAll(Func<ExpensesMaster, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public int GetRecordsCount()
        {
            throw new NotImplementedException();
        }

        public void Save(ExpensesMaster entity)
        {
            throw new NotImplementedException();
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