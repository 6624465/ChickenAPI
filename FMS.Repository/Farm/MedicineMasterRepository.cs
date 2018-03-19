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
    public class MedicineMasterRepository: IMedicineMasterRepository
    {
        private DBContext entities = null;
        public MedicineMasterRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(MedicineMaster entity)
        {
            try
            {
                entities.MedicineMasters.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(MedicineMaster entity)
        {
            try
            {
                entities.MedicineMasters.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(MedicineMaster entity)
        {
            try
            {
                entities.MedicineMasters.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MedicineMaster Get(Func<MedicineMaster, bool> predicate)
        {
            try
            {
                return entities.MedicineMasters.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<MedicineMaster> GetAll(Func<MedicineMaster, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.MedicineMasters.Where(predicate).AsQueryable();
                }
                return entities.MedicineMasters;
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

        public void Save(MedicineMaster entity)
        {
            try
            {
                MedicineMaster medicineMaster = entities.MedicineMasters
               .Where(x => x.FarmID == entity.FarmID && x.MedicineCode == entity.MedicineCode).FirstOrDefault();

                if (medicineMaster != null)
                {
                    entities.Entry(medicineMaster).State = EntityState.Modified;
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
        // ~MedicineMasterRepository() {
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