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
    public class TransporterHeaderRepository: ITransporterHeaderRepository
    {
        private DBContext entities = null;
        public TransporterHeaderRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(TransporterHeader entity)
        {
            try
            {
                entities.TransporterHeaders.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(TransporterHeader entity)
        {
            try
            {
                entities.TransporterHeaders.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TransporterHeader entity)
        {
            try
            {
                entities.TransporterHeaders.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransporterHeader Get(Func<TransporterHeader, bool> predicate)
        {
            try
            {
                return entities.TransporterHeaders.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TransporterHeader> GetAll(Func<TransporterHeader, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.TransporterHeaders.Where(predicate).AsQueryable();
                }
                return entities.TransporterHeaders;
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

        public void Save(TransporterHeader entity)
        {
            try
            {
                TransporterHeader transporterHeader = entities.TransporterHeaders
               .Where(x => x.FarmID == entity.FarmID && x.TransporterID == entity.TransporterID).FirstOrDefault();

                if (transporterHeader != null)
                {
                    entities.Entry(transporterHeader).State = EntityState.Modified;
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
        // ~TransporterHeaderRepository() {
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