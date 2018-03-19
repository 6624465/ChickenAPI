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
    public class VaccineMasterRepository: IVaccineMasterRepository
    {
        private DBContext entities = null;
        public VaccineMasterRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(VaccineMaster entity)
        {
            try
            {
                entities.VaccineMasters.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(VaccineMaster entity)
        {
            try
            {
                entities.VaccineMasters.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(VaccineMaster entity)
        {
            try
            {
                entities.VaccineMasters.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VaccineMaster Get(Func<VaccineMaster, bool> predicate)
        {
            try
            {
                return entities.VaccineMasters.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<VaccineMaster> GetAll(Func<VaccineMaster, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.VaccineMasters.Where(predicate).AsQueryable();
                }
                return entities.VaccineMasters;
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

        public void Save(VaccineMaster entity)
        {
            try
            {
                VaccineMaster vaccineMaster = entities.VaccineMasters
               .Where(x => x.FarmID == entity.FarmID && x.VaccineCode == entity.VaccineCode).FirstOrDefault();

                if (vaccineMaster != null)
                {
                    entities.Entry(vaccineMaster).State = EntityState.Modified;
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
        // ~VaccineMasterRepository() {
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