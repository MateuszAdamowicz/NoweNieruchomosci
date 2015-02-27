using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Context.Entities;
using Context.PartialModels;

namespace Context
{
    public interface INieruchomosciContext
    {
        IDbSet<Advert> Adverts { get; set; }
        IDbSet<Photo> Photos { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<Property> Properties { get; set; }
        IDbSet<PropertyDictionary> PropertyDictionaries { get; set; }
        IDbSet<AdvertType> AdvertTypes { get; set; }
        int SaveChanges();

        IDbSet<T> GetSet<T>() where T : DbTable;
        EntityState EntityState<T>(T entity) where T : DbTable;
        void Modified<T>(T entity) where T : DbTable;
    }
}