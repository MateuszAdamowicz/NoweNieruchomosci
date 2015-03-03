using System.Collections.Generic;
using Context.Entities;

namespace Services.GenericRepository
{
    public interface IGenericRepository<T> where T : BusinessObject
    {
        IEnumerable<T> GetSet();
        T Add(T entity);
        T Find(int id);
        T Delete(int id);
        T Update(T entity);
    }
}