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
    public class AnimalProfileRepository: IAnimalProfileRepository
    {
        private DBContext entities = null;
        public AnimalProfileRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(AnimalProfile entity)
        {
            try
            {
                entities.AnimalProfiles.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(AnimalProfile entity)
        {
            try
            {
                entities.AnimalProfiles.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(AnimalProfile entity)
        {
            try
            {
                entities.AnimalProfiles.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AnimalProfile Get(Func<AnimalProfile, bool> predicate)
        {
            try
            {
                return entities.AnimalProfiles.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<AnimalProfile> GetAll(Func<AnimalProfile, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.AnimalProfiles.Where(predicate).AsQueryable();
                }
                return entities.AnimalProfiles;
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

        public void Save(AnimalProfile entity)
        {
            try
            {
                AnimalProfile animalprofile = entities.AnimalProfiles
               .Where(x => x.AnimalCode == entity.AnimalCode).FirstOrDefault();

                if (animalprofile != null)
                {
                    entities.Entry(animalprofile).State = EntityState.Modified;
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
        // ~AnimalProfileRepository() {
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