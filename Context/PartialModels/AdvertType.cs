using System.ComponentModel;

namespace Context.PartialModels
{
    public enum AdvertType
    {
        [Description("Mieszkanie")]
        Flat = 1,

        [Description("Dom")]
        House = 2,

        [Description("Działka")]
        Land = 4
    }
}