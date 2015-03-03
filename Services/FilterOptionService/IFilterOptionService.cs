using Models.ViewModels;

namespace Services.FilterOptionService
{
    public interface IFilterOptionService
    {
        AdminIndexFilterOptions GetOptions();
    }
}