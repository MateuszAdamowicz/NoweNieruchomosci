using Models.ViewModels;

namespace Services.EnumNameService.Implementation
{
    public interface IEnumNameService
    {
        string GetName(AdType adType);
    }
}