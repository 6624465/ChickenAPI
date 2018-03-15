using Chicken.Contract.Farm;
using Chicken.EF;
using Chicken.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chicken.Repository.Farm
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private DBContext entities = null;
        public RegistrationRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(Registration entity)
        {
            try
            {
                entities.Registrations.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(Registration entity)
        {
            try
            {
                entities.Registrations.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Registration entity)
        {
            try
            {
                entities.Registrations.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Registration Get(Func<Registration, bool> predicate)
        {
            try
            {
                return entities.Registrations.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Registration> GetAll(Func<Registration, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.Registrations.Where(predicate).AsQueryable();
                }
                return entities.Registrations;
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

        public void Save(Registration entity)
        {
            try
            {
                Registration reg = entities.Registrations
               .Where(x => x.ID == entity.ID).FirstOrDefault();

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

        public void UpdateOTPStatus(Registration entity)
        {
            try
            {
                Registration reg = entities.Registrations
               .Where(x => x.ID == entity.ID).FirstOrDefault();

                if (reg != null && reg.OTPNo == entity.OTPNo)
                {
                    reg.IsOTPVerified = true;
                    entities.Entry(reg).State = EntityState.Modified;
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
        // ~RegistrationRepository() {
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