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
    public class RoleRepository: IRoleRepository
    {
        private DBContext entities = null;
        public RoleRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(Roles entity)
        {
            try
            {
                entities.Roless.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(Roles entity)
        {
            try
            {
                entities.Roless.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Roles entity)
        {
            try
            {
                entities.Roless.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Roles Get(Func<Roles, bool> predicate)
        {
            try
            {
                return entities.Roless.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Roles> GetAll(Func<Roles, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.Roless.Where(predicate).AsQueryable();
                }
                return entities.Roless;
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

        public void Save(Roles entity)
        {
            try
            {
                Roles roles = entities.Roless
               .Where(x => x.RoleCode == entity.RoleCode).FirstOrDefault();

                if (roles != null)
                {
                    entities.Entry(roles).State = EntityState.Modified;
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
        // ~RoleRepository() {
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