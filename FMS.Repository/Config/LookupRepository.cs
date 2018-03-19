using FMS.Contract.Config;
using FMS.EF;
using FMS.Repository.Config.IConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMS.Repository.Config
{
    public class LookupRepository: ILookupRepository
    {
        private DBContext entities = null;
        public LookupRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(Lookup entity)
        {
            try
            {
                entities.Lookups.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(Lookup entity)
        {
            try
            {
                entities.Lookups.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Lookup entity)
        {
            try
            {
                entities.Lookups.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Lookup Get(Func<Lookup, bool> predicate)
        {
            try
            {
                return entities.Lookups.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Lookup> GetAll(Func<Lookup, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.Lookups.Where(predicate).AsQueryable();
                }
                return entities.Lookups;
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

        public void Save(Lookup entity)
        {
            try
            {
                Lookup lookup = entities.Lookups
               .Where(x => x.LookupID == entity.LookupID).FirstOrDefault();

                if (lookup != null)
                {
                    entities.Entry(lookup).State = EntityState.Modified;
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
        // ~LookupRepository() {
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