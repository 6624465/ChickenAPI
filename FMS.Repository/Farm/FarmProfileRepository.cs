using FMS.Contract.Farm;
using FMS.EF;
using FMS.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FMS.Repository.Farm
{
    public class FarmProfileRepository: IFarmProfileRepository
    {
        private DBContext entities = null;
        public FarmProfileRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(FarmProfile entity)
        {
            try
            {
                entities.FarmProfiles.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(FarmProfile entity)
        {
            try
            {
                entities.FarmProfiles.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(FarmProfile entity)
        {
            try
            {
                entities.FarmProfiles.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FarmProfile Get(Func<FarmProfile, bool> predicate)
        {
            try
            {
                return entities.FarmProfiles.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<FarmProfile> GetAll(Func<FarmProfile, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.FarmProfiles.Where(predicate).AsQueryable();
                }
                return entities.FarmProfiles;
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

        public void Save(FarmProfile entity)
        {
            try
            {
                FarmProfile reg = entities.FarmProfiles
               .Where(x => x.MobileNo == entity.MobileNo).FirstOrDefault();

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
        // ~FarmProfileRepository() {
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