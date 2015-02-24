using System.Collections.Generic;

namespace Context.Entities
{
    public sealed class PropertyDictionary: DbTable
    {
        public PropertyDictionary()
        {
            Properties = new List<Property>();
        }

        public string Name { get; set; }
        public int Mask { get; set; }

        public List<Property> Properties { get; set; } 
    }
}