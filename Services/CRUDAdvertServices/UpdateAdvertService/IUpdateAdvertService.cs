using Models.ViewModels;

namespace Services.CRUDAdvertServices.UpdateAdvertService
{
    public interface IUpdateAdvertService
    {
        int UpdateAdvert(CreateAdvertViewModel updateAdvert);
        bool ChangeVisibility(int number);
    }
}