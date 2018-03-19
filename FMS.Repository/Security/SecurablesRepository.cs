using FMS.Contract.Security;
using FMS.EF;
using FMS.Repository.Security.ISecurity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMS.Repository.Security
{
    public class SecurablesRepository: ISecurablesRepository
    {
        private DBContext entities = null;
        public SecurablesRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(Securables entity)
        {
            try
            {
                entities.Securabless.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(Securables entity)
        {
            try
            {
                entities.Securabless.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Securables entity)
        {
            try
            {
                entities.Securabless.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Securables Get(Func<Securables, bool> predicate)
        {
            try
            {
                return entities.Securabless.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Securables> GetAll(Func<Securables, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.Securabless.Where(predicate).AsQueryable();
                }
                return entities.Securabless;
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

        public void Save(Securables entity)
        {
            try
            {
                Securables securables = entities.Securabless
               .Where(x => x.SecurableID == entity.SecurableID).FirstOrDefault();

                if (securables != null)
                {
                    entities.Entry(securables).State = EntityState.Modified;
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
        // ~SecurablesRepository() {
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