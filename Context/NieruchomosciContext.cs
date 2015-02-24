using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Context.Entities;

namespace Context
{
    public class NieruchomosciContext : DbContext, INieruchomosciContext
    {
        public IDbSet<Advert> Adverts { get; set; }
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<PropertyDictionary> PropertyDictionaries { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public IEnumerable<T> GetSet<T>() where T : DbTable
        {
            return base.Set<T>().Where(x => !x.Deleted);
        }

        public T Add<T>(T entity) where T : DbTable
        {
            var model =  base.Set<T>().Add(entity);
            SaveChanges();
            return model;
        }

        public T FindById<T>(int id) where T : DbTable
        {
            return base.Set<T>().Find(id);
        }

        public T DeleteById<T>(int id) where T : DbTable
        {
            var model = FindById<T>(id);
            model.Deleted = true;
            SaveChanges();
            return model;
        }

        public T UpdateById<T>(T source) where T : DbTable
        {
            var table = base.Set<T>();
            table.Attach(source);
            base.Entry(source).State = EntityState.Modified;
            SaveChanges();
            return source;
        }
    }

}
