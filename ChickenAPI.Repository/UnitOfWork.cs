using Chicken.Contract.Farm;
using Chicken.EF;
using Chicken.Repository.Farm;
using Chicken.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chicken.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DBContext entities = null;
        public UnitOfWork()
        {
            entities = new DBContext();
        }

        #region Farm Repository

        IRegistrationRepository registrationRepository = null;
        public IRegistrationRepository RegistrationRepository
        {
            get
            {
                if (registrationRepository == null)
                {
                    registrationRepository = new RegistrationRepository(entities);
                }
                return registrationRepository;
            }
        }

        #endregion Farm Repository





        public void SaveChanges()
        {
            entities.SaveChanges();
        }

        protected virtual void ConfigureContext(DBContext entities)
        {
            entities.Configuration.ProxyCreationEnabled = false;
            entities.Configuration.LazyLoadingEnabled = false;
            entities.Configuration.ValidateOnSaveEnabled = false;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            //if (!this.disposed)
            //{
            //    if (disposing)
            //    {
            //        entities.Dispose();
            //    }
            //}
            //this.disposed = true;
            if (!disposing)
            {
                return;
            }

            if (this.entities == null)
            {
                return;
            }

            this.entities.Dispose();
            this.entities = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}