using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Context;
using Context.Entities;

namespace Services.GenericRepository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BusinessObject
    {
        private readonly INieruchomosciContext _context;

        public GenericRepository(INieruchomosciContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetSet()
        {
            return _context.GetSet<T>().Where(x => !x.Deleted);
        }

        public T Add(T entity)
        {
            var model = _context.GetSet<T>().Add(entity);
            _context.SaveChanges();
            return model;
        }

        public T Find(int id)
        {
            return _context.GetSet<T>().Single(entity => entity.Id == id);
        }

        public T Delete(int id)
        {
            var entity = Find(id);
            entity.Deleted = true;
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (_context.EntityState(entity) == EntityState.Detached)
            {
                _context.GetSet<T>().Attach(entity);
                
            }
            _context.Modified(entity);
            return entity;
        }
    }
}