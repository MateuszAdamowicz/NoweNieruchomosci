using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Context;
using Context.Entities;

namespace Services.GenericRepository.Implementation
{
    [ExcludeFromCodeCoverage]
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
            var entity = _context.GetSet<T>().Find(id);
            if (entity != null && entity.Deleted)
            {
                return null;
            }
            return entity;
        }

        public T Delete(int id)
        {
            var entity = Find(id);
            if (entity != null)
            {
                entity.Deleted = true;
                _context.SaveChanges();   
            }
            return entity;
        }

        public T Update(T entity)
        {
            _context.Modified(entity);
            return entity;
        }
    }
}