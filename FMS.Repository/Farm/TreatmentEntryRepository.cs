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
    public class TreatmentEntryRepository : ITreatmentEntryRepository
    {
        private DBContext entities = null;
        public TreatmentEntryRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(TreatmentEntry entity)
        {
            try
            {
                entities.TreatmentEntrys.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(TreatmentEntry entity)
        {
            try
            {
                entities.TreatmentEntrys.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TreatmentEntry entity)
        {
            try
            {
                entities.TreatmentEntrys.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TreatmentEntry Get(Func<TreatmentEntry, bool> predicate)
        {
            try
            {
                return entities.TreatmentEntrys.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TreatmentEntry> GetAll(Func<TreatmentEntry, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.TreatmentEntrys.Where(predicate).AsQueryable();
                }
                return entities.TreatmentEntrys;
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

        public void Save(TreatmentEntry entity)
        {
            try
            {
                TreatmentEntry transporterHeader = entities.TreatmentEntrys
               .Where(x => x.FarmID == entity.FarmID && x.RecordID == entity.RecordID).FirstOrDefault();

                if (transporterHeader != null)
                {
                    entities.Entry(transporterHeader).State = EntityState.Modified;
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
        // ~TreatmentEntryRepository() {
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