using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Models.ViewModels;
using Services.DetailedSortService.Implementation.Engines;

namespace Services.DetailedSortService.Implementation
{
    [ExcludeFromCodeCoverage]
    public class DetailedSortService : IDetailedSortService
    {
        private readonly Dictionary<AdminSortOption, IDetailedSort> _sortEngines;

        public DetailedSortService(IDetailedSortCreatedAt detailedSortCreatedAt,
            IDetailedSortCity detailedSortCity,
            IDetailedSortArea detailedSortArea,
            IDetailedSortNumber detailedSortNumber,
            IDetailedSortAdType detailedSortAdType,
            IDetailedSortPrice detailedSortPrice,
            IDetailedSortToLet detailedSortToLet,
            IDetailedSortVisible detailedSortVisible)
        {
            _sortEngines = new Dictionary<AdminSortOption, IDetailedSort>();

            _sortEngines.Add(AdminSortOption.CreatedAt, detailedSortCreatedAt);
            _sortEngines.Add(AdminSortOption.City, detailedSortCity);
            _sortEngines.Add(AdminSortOption.Area, detailedSortArea);
            _sortEngines.Add(AdminSortOption.Number, detailedSortNumber);
            _sortEngines.Add(AdminSortOption.AdType, detailedSortAdType);
            _sortEngines.Add(AdminSortOption.Price, detailedSortPrice);
            _sortEngines.Add(AdminSortOption.ToLet, detailedSortToLet);
            _sortEngines.Add(AdminSortOption.Visible, detailedSortVisible);
        }

        public IEnumerable<AdminAdvertToShow> Sort(AdminSortOption engine, IEnumerable<AdminAdvertToShow> adverts)
        {
            return _sortEngines[engine].Sort(adverts);
        } 
    }
}