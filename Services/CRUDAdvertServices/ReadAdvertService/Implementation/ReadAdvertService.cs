using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.CRUDAdvertServices.ReadAdvertService.Implementation
{
    public class ReadAdvertService : IReadAdvertService
    {
        private readonly IGenericRepository<Advert> _advertRepository;

        public ReadAdvertService(IGenericRepository<Advert>  advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public ShowAdvertViewModel GetAdvertById(int id)
        {
            var advert = _advertRepository.Find(id);

            if (advert.Visible)
            {
                var model = AutoMapper.Mapper.Map<ShowAdvertViewModel>(advert);

                return model;
            }
            return null;
        }

        public CreateAdvertViewModel GetCreateAdvertById(int id)
        {
            var advert = _advertRepository.Find(id);

            var model = AutoMapper.Mapper.Map<CreateAdvertViewModel>(advert);

            return model;
        }

        public ShowAdvertViewModel GetAdvertByIdIncludeHidden(int id)
        {
            var advert = _advertRepository.Find(id);

            var model = AutoMapper.Mapper.Map<ShowAdvertViewModel>(advert);

            return model;
        }
    }
}