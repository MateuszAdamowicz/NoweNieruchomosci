using Models.ViewModels;

namespace Services.CRUDAdvertServices.UpdateAdvertService
{
    public interface IUpdateAdvertService
    {
        int UpdateAdvert(CreateAdvertViewModel updateAdvert, int id);
        bool ChangeVisibility(int number);
    }
}