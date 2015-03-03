using Models.ViewModels;

namespace Services.CountMessagesAndAdverts
{
    public interface ICountMessagesAndAdverts
    {
        AdminMenuViewModel Count(AdminMenuViewModel adminMenuViewModel);
    }
}