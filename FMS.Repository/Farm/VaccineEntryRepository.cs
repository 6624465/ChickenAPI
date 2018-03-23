using FMS.Contract.Farm;
using FMS.EF;
using FMS.Repository.Farm.IFarm;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FMS.Repository.Farm
{
    public class VaccineEntryRepository : IVaccineEntryRepository
    {
        private DBContext entities = null;
        public VaccineEntryRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(VaccineEntry entity)
        {
            try
            {
                entities.VaccineEntrys.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(VaccineEntry entity)
        {
            try
            {
                entities.VaccineEntrys.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(VaccineEntry entity)
        {
            try
            {
                entities.VaccineEntrys.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VaccineEntry Get(Func<VaccineEntry, bool> predicate)
        {
            try
            {
                return entities.VaccineEntrys.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<VaccineEntry> GetAsync(Func<VaccineEntry, bool> predicate)
        {
            try
            {
                return await entities.VaccineEntrys.Where(predicate).AsQueryable().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<VaccineEntry> GetAll(Func<VaccineEntry, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.VaccineEntrys.Where(predicate).AsQueryable();
                }
                return entities.VaccineEntrys;
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

        public void Save(VaccineEntry entity)
        {
            try
            {
                VaccineEntry vaccineEntry = entities.VaccineEntrys
               .Where(x => x.FarmID == entity.FarmID && x.RecordID == entity.RecordID && x.AnimalCode == entity.AnimalCode).FirstOrDefault();

                if (vaccineEntry != null)
                {
                    entities.Entry(vaccineEntry).State = EntityState.Modified;
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
        // ~VaccineEntryRepository() {
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