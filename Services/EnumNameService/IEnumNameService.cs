using Context.PartialModels;

namespace Services.EnumNameService
{
    public interface IEnumNameService
    {
        string GetName(AdvertType adType);
    }
}