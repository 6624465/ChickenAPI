using FMS.Contract.Security;
using FMS.EF;
using FMS.Repository.Security.ISecurity;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Attach(Roles entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Roles entity)
        {
            throw new NotImplementedException();
        }

        public Roles Get(Func<Roles, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Roles> GetAll(Func<Roles, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public int GetRecordsCount()
        {
            throw new NotImplementedException();
        }

        public void Save(Roles entity)
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