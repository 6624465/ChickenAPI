using FMS.Repository.Farm.IFarm;
using FMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMS.Contract.Farm;
using System.Data.Entity;

namespace FMS.Repository.Farm
{
    public class StandardPriceRepository: IStandardPriceRepository
    {
        private DBContext entities = null;
        public StandardPriceRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(StandardPrice entity)
        {
            try
            {
                entities.StandardPrices.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(StandardPrice entity)
        {
            try
            {
                entities.StandardPrices.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(StandardPrice entity)
        {
            try
            {
                entities.StandardPrices.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StandardPrice Get(Func<StandardPrice, bool> predicate)
        {
            try
            {
                return entities.StandardPrices.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<StandardPrice> GetAll(Func<StandardPrice, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.StandardPrices.Where(predicate).AsQueryable();
                }
                return entities.StandardPrices;
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

        public void Save(StandardPrice entity)
        {
            try
            {
                StandardPrice standardPrice = entities.StandardPrices
               .Where(x => x.FarmID == entity.FarmID && x.StandardPriceId == entity.StandardPriceId).FirstOrDefault();

                if (standardPrice != null)
                {
                    entities.Entry(standardPrice).State = EntityState.Modified;
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
        // ~StandardPriceRepository() {
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