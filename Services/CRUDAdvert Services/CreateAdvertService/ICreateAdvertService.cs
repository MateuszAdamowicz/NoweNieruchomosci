using Models.ViewModels;

namespace Services.CRUD.AdvertServices.CreateAdvertService
{
    public interface ICreateAdvertService
    {
        int CreateAdvert(CreateAdvertViewModel createAdvert);
    }
}