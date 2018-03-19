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
    public class UserRightsRepository : IUserRightsRepository
    {
        private DBContext entities = null;
        public UserRightsRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(UserRights entity)
        {
            try
            {
                entities.UserRightss.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(UserRights entity)
        {
            try
            {
                entities.UserRightss.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(UserRights entity)
        {
            try
            {
                entities.UserRightss.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserRights Get(Func<UserRights, bool> predicate)
        {
            try
            {
                return entities.UserRightss.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<UserRights> GetAll(Func<UserRights, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.UserRightss.Where(predicate).AsQueryable();
                }
                return entities.UserRightss;
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

        public void Save(UserRights entity)
        {
            try
            {
                UserRights userRights = entities.UserRightss
               .Where(x => x.UserID == entity.UserID && x.SecurableItem == entity.SecurableItem && x.LinkGroup == entity.LinkGroup && x.LinkID == entity.LinkID).FirstOrDefault();

                if (userRights != null)
                {
                    entities.Entry(userRights).State = EntityState.Modified;
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
        // ~UserRightsRepository() {
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