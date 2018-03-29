﻿
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
    public class AnimalSaleEntryRepository: IAnimalSaleEntryRepository
    {

        private DBContext entities = null;
        public AnimalSaleEntryRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(AnimalSaleEntry entity)
        {
            try
            {
                entities.AnimalSaleEntrys.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(AnimalSaleEntry entity)
        {
            try
            {
                entities.AnimalSaleEntrys.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(AnimalSaleEntry entity)
        {
            try
            {
                entities.AnimalSaleEntrys.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AnimalSaleEntry Get(Func<AnimalSaleEntry, bool> predicate)
        {
            try
            {
                return entities.AnimalSaleEntrys.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<AnimalSaleEntry> GetAll(Func<AnimalSaleEntry, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.AnimalSaleEntrys.Where(predicate).AsQueryable();
                }
                return entities.AnimalSaleEntrys;
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

        public void Save(AnimalSaleEntry entity)
        {
            try
            {
                AnimalSaleEntry animalSaleEntry = entities.AnimalSaleEntrys
               .Where(x => x.SaleEntryID == entity.SaleEntryID).FirstOrDefault();

                if (animalSaleEntry != null)
                {
                    entities.Entry(animalSaleEntry).State = EntityState.Modified;
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
        // ~AnimalSaleEntryRepository() {
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