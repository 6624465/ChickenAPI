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
    public class RoleRightsRepository : IRoleRightsRepository
    {
        private DBContext entities = null;
        public RoleRightsRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(RoleRights entity)
        {
            try
            {
                entities.RoleRightss.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(RoleRights entity)
        {
            try
            {
                entities.RoleRightss.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(RoleRights entity)
        {
            try
            {
                entities.RoleRightss.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RoleRights Get(Func<RoleRights, bool> predicate)
        {
            try
            {
                return entities.RoleRightss.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<RoleRights> GetAll(Func<RoleRights, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.RoleRightss.Where(predicate).AsQueryable();
                }
                return entities.RoleRightss;
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

        public void Save(RoleRights entity)
        {
            try
            {
                RoleRights roleRights = entities.RoleRightss
               .Where(x => x.RoleCode == entity.RoleCode && x.CompanyCode == entity.CompanyCode && x.SecurableItem == entity.SecurableItem).FirstOrDefault();

                if (roleRights != null)
                {
                    entities.Entry(roleRights).State = EntityState.Modified;
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
        // ~RoleRightsRepository() {
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