using System;
using System.ComponentModel;
using System.Linq;
using Context.PartialModels;

namespace Services.EnumNameService.Implementation
{
    public class EnumNameService : IEnumNameService
    {
        public string GetName(AdvertType adType)
        {
            return Enum.GetName(typeof (AdvertType), adType);
        }
    }
}