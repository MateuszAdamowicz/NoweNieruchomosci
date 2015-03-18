using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Context.Entities;
using Context.PartialModels;

namespace Context
{
    [ExcludeFromCodeCoverage]
    public class NieruchomosciContext : DbContext, INieruchomosciContext
    {
        public IDbSet<Advert> Adverts { get; set; }
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<PropertyDictionary> PropertyDictionaries { get; set; }
        public IDbSet<AdvertType> AdvertTypes { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public IDbSet<T> GetSet<T>() where T: BusinessObject
        {
            return Set<T>();
        }

        public EntityState EntityState<T>(T entity) where T : BusinessObject
        {
            return Entry(entity).State;
        }


        public void Modified<T>(T entity) where T : BusinessObject
        {
            GetSet<T>().Attach(entity);
            Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }

    }

}
