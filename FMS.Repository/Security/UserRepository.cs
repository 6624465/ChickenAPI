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
    public class UserRepository: IUserRepository
    {
        private DBContext entities = null;
        public UserRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(User entity)
        {
            try
            {
                entities.Users.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(User entity)
        {
            try
            {
                entities.Users.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(User entity)
        {
            try
            {
                entities.Users.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Get(Func<User, bool> predicate)
        {
            try
            {
                return entities.Users.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<User> GetAll(Func<User, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.Users.Where(predicate).AsQueryable();
                }
                return entities.Users;
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

        public void Save(User entity)
        {
            try
            {
                User reg = entities.Users
               .Where(x => x.UserID == entity.UserID).FirstOrDefault();

                if (reg != null) 
                {
                    entities.Entry(reg).State = EntityState.Modified;
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
        // ~UserRepository() {
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