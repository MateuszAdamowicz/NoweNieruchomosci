using Models.ViewModels;
namespace Services.AdminMenuServices
{
    public interface IAdminMenuService
    {
         AdminMenuCountsViewModel GetMenuCounters();
    }
}