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
    public class VaccineScheduleRepository: IVaccineScheduleRepository
    {
        private DBContext entities = null;
        public VaccineScheduleRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(VaccineSchedule entity)
        {
            try
            {
                entities.VaccineSchedules.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(VaccineSchedule entity)
        {
            try
            {
                entities.VaccineSchedules.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(VaccineSchedule entity)
        {
            try
            {
                entities.VaccineSchedules.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VaccineSchedule Get(Func<VaccineSchedule, bool> predicate)
        {
            try
            {
                return entities.VaccineSchedules.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<VaccineSchedule> GetAll(Func<VaccineSchedule, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.VaccineSchedules.Where(predicate).AsQueryable();
                }
                return entities.VaccineSchedules;
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

        public void Save(VaccineSchedule entity)
        {
            try
            {
                VaccineSchedule vaccineSchedule = entities.VaccineSchedules
               .Where(x => x.FarmID == entity.FarmID && x.VaccineScheduleId == entity.VaccineScheduleId).FirstOrDefault();

                if (vaccineSchedule != null)
                {
                    entities.Entry(vaccineSchedule).State = EntityState.Modified;
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
        // ~VaccineScheduleRepository() {
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