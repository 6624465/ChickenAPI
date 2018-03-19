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
    public class TransporterRouteRepository : ITransporterRouteRepository
    {
        private DBContext entities = null;
        public TransporterRouteRepository(DBContext _entities)
        {
            entities = _entities;
        }

        public void Add(TransporterRoute entity)
        {
            try
            {
                entities.TransporterRoutes.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Attach(TransporterRoute entity)
        {
            try
            {
                entities.TransporterRoutes.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(TransporterRoute entity)
        {
            try
            {
                entities.TransporterRoutes.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransporterRoute Get(Func<TransporterRoute, bool> predicate)
        {
            try
            {
                return entities.TransporterRoutes.Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TransporterRoute> GetAll(Func<TransporterRoute, bool> predicate = null)
        {
            try
            {
                if (predicate != null)
                {
                    return entities.TransporterRoutes.Where(predicate).AsQueryable();
                }
                return entities.TransporterRoutes;
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

        public void Save(TransporterRoute entity)
        {
            try
            {
                TransporterRoute transporterRoute = entities.TransporterRoutes
               .Where(x => x.FarmID == entity.FarmID && x.TransporterID == entity.TransporterID && x.Origin == entity.Origin).FirstOrDefault();

                if (transporterRoute != null)
                {
                    entities.Entry(transporterRoute).State = EntityState.Modified;
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
        // ~TransporterRouteRepository() {
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