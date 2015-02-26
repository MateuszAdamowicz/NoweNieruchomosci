using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Context.Entities;
using Context.PartialModels;

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
            //var prop1 = new PropertyDictionary() {Mask = 1, Name = "Forma własności"};
            //var prop2 = new PropertyDictionary() {Mask = 1, Name = "Ogrzewanie"};
            //var prop3 = new PropertyDictionary() {Mask = 1, Name = "Kondygnacja"};
            //var prop4 = new PropertyDictionary() {Mask = 1, Name = "Stan techniczny"};
            //var prop5 = new PropertyDictionary() {Mask = 1, Name = "Liczba pokoi"};


            //var advert1 = new Advert()
            //{
            //    AdvertType = AdvertType.Flat,
            //    Area = 123,
            //    City = "Szczecin",
            //    Deleted = false,
            //    Description =
            //        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum eleifend ornare pharetra. Nam quam lectus, tristique eget ligula a, euismod semper lectus. Mauris lobortis, orci nec blandit blandit, odio orci hendrerit leo, a iaculis urna risus id eros. Aliquam ac lectus eu nunc egestas scelerisque dignissim id quam. Aenean justo turpis, suscipit eget condimentum eu, posuere sed lorem. Phasellus auctor, quam eget fermentum dapibus, ipsum odio semper odio, in cursus leo magna vitae nibh. Pellentesque a odio et dui consequat venenatis quis quis tellus. Mauris in dui lacus. Aenean iaculis magna in feugiat placerat. Fusce ornare eros enim, nec elementum turpis pretium ut. Praesent posuere massa eu rhoncus mollis. Ut condimentum turpis sit amet lacus bibendum, id scelerisque neque accumsan. Vivamus iaculis quis purus quis vehicula. Sed diam massa, hendrerit non iaculis ut, laoreet id neque. Duis purus elit, placerat nec consectetur at, facilisis sed risus. Vivamus ac mauris vulputate, tincidunt metus sit amet, viverra quam.",
            //    Details =
            //        "Curabitur posuere, quam ac feugiat convallis, diam dui tincidunt arcu, ut eleifend est eros a risus. Quisque sapien mauris, posuere eget diam a, pellentesque volutpat mi. Vivamus dignissim, purus ac congue lobortis, lectus ex cursus felis, sed efficitur ex urna nec dolor. Donec ullamcorper sapien ut ex consectetur, sit amet faucibus purus faucibus. Ut porttitor, enim et semper porttitor, eros magna posuere mi, ut vulputate mauris lorem ac nibh. Aliquam commodo tincidunt nibh, vitae efficitur risus pharetra in. Ut id tristique augue.",
            //    MapCords = new MapCords()
            //};

            //context.Adverts.Add(advert1);
            //context.PropertyDictionaries.Add(prop1);
            //context.PropertyDictionaries.Add(prop2);
            //context.PropertyDictionaries.Add(prop3);
            //context.PropertyDictionaries.Add(prop4);
            //context.PropertyDictionaries.Add(prop5);
            //context.SaveChanges();
        }
    }
}