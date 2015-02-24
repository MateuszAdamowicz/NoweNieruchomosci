using Context.PartialModels;

namespace Context.Entities
{
    public class Property: DbTable
    {
        public virtual Advert Advert { get; set; }
        public virtual AdvertType AdvertType { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}