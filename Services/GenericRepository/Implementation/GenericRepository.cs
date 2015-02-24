using System.Collections.Generic;
using Context;
using Context.Entities;

namespace Services.GenericRepository.Implementation
{
    public class GenericRepository : IGenericRepository
    {
        private readonly INieruchomosciContext _context;

        public GenericRepository(INieruchomosciContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetSet<T>() where T:DbTable
        {
            return _context.GetSet<T>();
        }

        public T Add<T>(T entity) where T : DbTable
        {
            return _context.Add<T>(entity);
        }

        public T Find<T>(int id) where T : DbTable
        {
            return _context.FindById<T>(id);
        }

        public T Delete<T>(int id) where T : DbTable
        {
            return _context.DeleteById<T>(id);
        }

        public T Update<T>(T entity) where T : DbTable
        {
            return _context.UpdateById(entity);
        }
    }
}