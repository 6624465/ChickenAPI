using FMS.Contract.Farm;
using FMS.EF;
using FMS.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMS.Repository.Farm
{
    public class FarmProfileRepository: IFarmProfileRepository
    {
        private DBContext entities = null;
        public FarmProfileRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(FarmProfile entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(FarmProfile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(FarmProfile entity)
        {
            throw new NotImplementedException();
        }

        public FarmProfile Get(Func<FarmProfile, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FarmProfile> GetAll(Func<FarmProfile, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public int GetRecordsCount()
        {
            throw new NotImplementedException();
        }

        public void Save(FarmProfile entity)
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
        // ~FarmProfileRepository() {
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