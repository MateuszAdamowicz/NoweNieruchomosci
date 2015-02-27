using System.Collections.Generic;
using System.ComponentModel;
using Context.Entities;

namespace Context.PartialModels
{
    public class AdvertType:DbTable
    {
        public string Name { get; set; }
        public int Mask { get; set; }

        public virtual IEnumerable<Advert> Adverts { get; set; }
    }
}