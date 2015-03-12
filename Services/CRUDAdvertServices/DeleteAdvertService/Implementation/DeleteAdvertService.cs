using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.CRUDAdvertServices.DeleteAdvertService.Implementation
{
    public class DeleteAdvertService : IDeleteAdvertService
    {
        private readonly IGenericRepository<Advert> _advertRepository;

        public DeleteAdvertService(IGenericRepository<Advert> advertRepository )
        {
            _advertRepository = advertRepository;
        }

        public int DeleteAdvert(int id)
        {
            _advertRepository.Delete(id);
            return id;
        }
    }
}