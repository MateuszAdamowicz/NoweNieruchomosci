using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;
using Context.Entities;
using Context.PartialModels;

namespace Context
{
    [ExcludeFromCodeCoverage]
    public class Configuration : DbMigrationsConfiguration<NieruchomosciContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Context.ApplicationContext";
        }

        protected override void Seed(NieruchomosciContext context)
        {

            var flat = new AdvertType(){Name = "Mieszkanie", Mask = 1};
            var house = new AdvertType(){Name = "Dom", Mask = 2};
            var land = new AdvertType(){Name = "Działka", Mask = 4};


            context.AdvertTypes.AddOrUpdate(x => x.Name, flat);
            context.AdvertTypes.AddOrUpdate(x => x.Name, house);
            context.AdvertTypes.AddOrUpdate(x => x.Name, land);


            var properties = new List<PropertyDictionary>
            {
                new PropertyDictionary() {Name = "Forma własności", Mask = 1 + 2 + 4},
                new PropertyDictionary() {Name = "Ogrzewanie", Mask = 1 + 2},
                new PropertyDictionary() {Name = "Kondygnacja", Mask = 1},
                new PropertyDictionary() {Name = "Stan techniczny", Mask = 1 + 2},
                new PropertyDictionary() {Name = "Liczba pokoi", Mask = 1 + 2},
                new PropertyDictionary() {Name = "Liczba pomieszczeń", Mask = 1 + 2}
            };


            foreach (var prop in properties)
            {
                context.PropertyDictionaries.AddOrUpdate(x => x.Name, prop);
            }

            context.SaveChanges();
        }
    }
}