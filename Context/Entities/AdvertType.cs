using System.Collections.Generic;

namespace Context.Entities
{
    public class AdvertType:BusinessObject
    {
        public string Name { get; set; }
        public int Mask { get; set; }

        public virtual IEnumerable<Advert> Adverts { get; set; }
    }
}