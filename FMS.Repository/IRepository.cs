using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        int GetRecordsCount();
        IQueryable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        void Save(T entity);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}
