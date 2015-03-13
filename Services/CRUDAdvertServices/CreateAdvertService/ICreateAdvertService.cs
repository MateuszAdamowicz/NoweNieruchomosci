using Models.ViewModels;

namespace Services.CRUDAdvertServices.CreateAdvertService
{
    public interface ICreateAdvertService
    {
        int CreateAdvert(CreateAdvertViewModel createAdvert);
    }
}