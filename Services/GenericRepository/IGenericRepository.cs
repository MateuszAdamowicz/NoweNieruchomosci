using System.Collections.Generic;
using Context.Entities;

namespace Services.GenericRepository
{
    public interface IGenericRepository
    {
        IEnumerable<T> GetSet<T>() where T:DbTable;
        T Add<T>(T entity) where T : DbTable;
        T Find<T>(int id) where T : DbTable;
        T Delete<T>(int id) where T : DbTable;
        T Update<T>(T entity) where T : DbTable;
    }
}