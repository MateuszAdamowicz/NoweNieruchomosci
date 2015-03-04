using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;

namespace Services.CitiesService.Implementation
{
    public class CitiesService : ICitiesService
    {
        private readonly IGenericRepository<Advert> _advertRepository;

        public CitiesService(IGenericRepository<Advert> advertRepository )
        {
            _advertRepository = advertRepository;
        }

        public IEnumerable<CityCount> CitiesWithMaximumNumberOfAdverts(int count)
        {
            var cities = _advertRepository.GetSet().GroupBy(x => x.City).OrderByDescending(x => x.Count()).Take(count);
            var citiesToShow = cities.Select(x => new CityCount() {CityName = x.Key, Count = x.Count()});
            return citiesToShow;
        }
    }
}