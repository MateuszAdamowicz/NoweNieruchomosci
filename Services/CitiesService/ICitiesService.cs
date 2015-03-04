using System.Collections.Generic;
using Models.ViewModels;

namespace Services.CitiesService
{
    public interface ICitiesService
    {
        IEnumerable<CityCount> CitiesWithMaximumNumberOfAdverts(int count);
    }
}