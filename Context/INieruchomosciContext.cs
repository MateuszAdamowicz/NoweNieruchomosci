using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Context.Entities;

namespace Context
{
    public interface INieruchomosciContext
    {
        IDbSet<Advert> Adverts { get; set; }
        IDbSet<Photo> Photos { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<Property> Properties { get; set; }
        IDbSet<PropertyDictionary> PropertyDictionaries { get; set; }
        int SaveChanges();

        IEnumerable<T> GetSet<T>() where T : DbTable;
        T Add<T>(T entity) where T : DbTable;
        T FindById<T>(int id) where T : DbTable;
        T DeleteById<T>(int id) where T : DbTable;
        T UpdateById<T>(T source) where T : DbTable;
    }
}