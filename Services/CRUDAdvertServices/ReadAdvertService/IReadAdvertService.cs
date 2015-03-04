using Models.ViewModels;

namespace Services.CRUDAdvertServices.ReadAdvertService
{
    public interface IReadAdvertService
    {
        ShowAdvertViewModel GetAdvertById(int id);
    }
}