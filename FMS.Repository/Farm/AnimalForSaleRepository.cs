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
    public class AnimalForSaleRepository: IAnimalForSaleRepository
    {
        private DBContext entities = null;
        public AnimalForSaleRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(AnimalForSale entity)
        {
            try
            {
                entities.AnimalForSales.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(AnimalForSale entity)
        {
            try
            {
                entities.AnimalForSales.Attach(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(AnimalForSale entity)
        {
            try
            {
                entities.AnimalForSales.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AnimalForSale Get(Func<AnimalForSale, bool> predicate)
        {
            try
            {
                return entities.AnimalForSales.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<AnimalForSale> GetAll(Func<AnimalForSale, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.AnimalForSales.Where(predicate).AsQueryable();
                }
                return entities.AnimalForSales;
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

        public void Save(AnimalForSale entity)
        {
            try
            {
                AnimalForSale animalForSale = entities.AnimalForSales
               .Where(x => x.SaleID == entity.SaleID).FirstOrDefault();

                if (animalForSale != null)
                {
                    entities.Entry(animalForSale).State = EntityState.Modified;
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
        // ~AnimalForSaleRepository() {
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