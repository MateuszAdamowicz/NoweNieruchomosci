using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Context.Entities;

namespace Context
{
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
            var prop1 = new PropertyDictionary() {Mask = 1, Name = "Forma własności"};
            var prop2 = new PropertyDictionary() {Mask = 1, Name = "Ogrzewanie"};
            var prop3 = new PropertyDictionary() {Mask = 1, Name = "Kondygnacja"};
            var prop4 = new PropertyDictionary() {Mask = 1, Name = "Stan techniczny"};
            var prop5 = new PropertyDictionary() {Mask = 1, Name = "Liczba pokoi"};


            context.PropertyDictionaries.Add(prop1);
            context.PropertyDictionaries.Add(prop2);
            context.PropertyDictionaries.Add(prop3);
            context.PropertyDictionaries.Add(prop4);
            context.PropertyDictionaries.Add(prop5);
            context.SaveChanges();
        }
    }
}