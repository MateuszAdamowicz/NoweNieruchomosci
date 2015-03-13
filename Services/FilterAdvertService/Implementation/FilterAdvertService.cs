using System;
using System.Collections.Generic;
using System.Linq;
using Context.Entities;
using Models.ViewModels;
using Services.GenericRepository;
using AutoMapper;
using Services.SortAdvertService;

namespace Services.FilterAdvertService.Implementation
{
    public class FilterAdvertService : IFilterAdvertService
    {
        private readonly IGenericRepository<Advert> _genericRepository;
        private readonly ISortAdvertService _sortAdvertService;

        public FilterAdvertService(IGenericRepository<Advert> genericRepository, ISortAdvertService sortAdvertService)
        {
            _genericRepository = genericRepository;
            _sortAdvertService = sortAdvertService;
        }
        public IEnumerable<AdminAdvertToShow> ActiveAdverts(AdminSortOption? adminSortOption, bool sortDescAsc)
        {
            var adverts = _genericRepository.GetSet().Where(x => x.Visible);
            var advertsToShow = Mapper.Map<IEnumerable<AdminAdvertToShow>>(adverts);

            advertsToShow = _sortAdvertService.SortAdverts(advertsToShow, adminSortOption, sortDescAsc);

            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdverts(bool? showHidden, DateTime? dateFrom, DateTime? dateTo, int? adType, string number, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, string city, bool? toLet, AdminSortOption? adminSortOption, bool sortDescAsc)
        {
            var adverts = _genericRepository.GetSet();
            var advertsToShow = Mapper.Map<IEnumerable<AdminAdvertToShow>>(adverts);

            advertsToShow = FilterAdvertsByCity(city, advertsToShow);
            advertsToShow = FilterAdvertsByNumber(number, advertsToShow);
            advertsToShow = FilterHiddenAdverts(showHidden, advertsToShow);
            advertsToShow = FilterAdvertsByDate(dateFrom, dateTo, advertsToShow);
            advertsToShow = FilterAdvertsByPrice(priceFrom, priceTo, advertsToShow);
            advertsToShow = FilterAdvertsByArea(areaFrom, areaTo, advertsToShow);
            advertsToShow = FilterAdvertsByAdvertType(adType, advertsToShow);
            advertsToShow = FilterAdvertsByToLet(toLet, advertsToShow);

            advertsToShow = _sortAdvertService.SortAdverts(advertsToShow, adminSortOption, sortDescAsc);


            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByCity(string city, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (!String.IsNullOrEmpty(city))
            {
                advertsToShow = advertsToShow.Where(x => x.City == city);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByNumber(string number, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (!String.IsNullOrEmpty(number))
            {
                advertsToShow = advertsToShow.Where(x => x.Number == number);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterHiddenAdverts(bool? showHidden, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (showHidden == false)
            {
                advertsToShow = advertsToShow.Where(x => x.Visible);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByDate(DateTime? dateFrom, DateTime? dateTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            advertsToShow = FilterAdvertsByFromDate(dateFrom, advertsToShow);
            advertsToShow = FilterAdvertsByToDate(dateTo, advertsToShow);
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByToDate(DateTime? dateTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (dateTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt.Date <= dateTo);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByFromDate(DateTime? dateFrom, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (dateFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt.Date >= dateFrom);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByPrice(int? priceFrom, int? priceTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            advertsToShow = FilterAdvertsByFromPrice(priceFrom, advertsToShow);
            advertsToShow = FilterAdvertsByToPrice(priceTo, advertsToShow);
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByToPrice(int? priceTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (priceTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Price <= priceTo);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByFromPrice(int? priceFrom, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (priceFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Price >= priceFrom);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByArea(int? areaFrom, int? areaTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            advertsToShow = FilterAdvertsByFromArea(areaFrom, advertsToShow);
            advertsToShow = FilterAdvertsByToArea(areaTo, advertsToShow);
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByToArea(int? areaTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (areaTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Area <= areaTo);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByFromArea(int? areaFrom, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (areaFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Area >= areaFrom);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByAdvertType(int? adType, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (adType != null)
            {
                advertsToShow = advertsToShow.Where(x => x.AdType.Mask == adType);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdvertsByToLet(bool? toLet, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (toLet != null)
            {
                advertsToShow = advertsToShow.Where(x => x.ToLet == toLet);
            }
            return advertsToShow;
        }
    }
}