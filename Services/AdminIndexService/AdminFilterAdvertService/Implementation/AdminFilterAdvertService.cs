using System;
using System.Collections.Generic;
using System.Linq;
using Context;
using Context.Entities;
using Context.PartialModels;
using Models.ViewModels;
using Services.GenericRepository;
using Services.SortService.SortAdminService;
using Services.SortService.SortAdminService.Implementation;

namespace Services.AdminIndexService.AdminFilterAdvertService.Implementation
{
    public class AdminFilterAdvertService : IAdminFilterAdvertService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ISortAdminService _sortAdminService;

        public AdminFilterAdvertService(IGenericRepository genericRepository, ISortAdminService sortAdminService)
        {
            _genericRepository = genericRepository;
            _sortAdminService = sortAdminService;
        }

        public IEnumerable<AdminAdvertToShow> FilterAdverts(bool? showHidden, DateTime? dateFrom, DateTime? dateTo, AdTypeAdmin? adType, string number, int? priceFrom, int? priceTo, int? areaFrom, int? areaTo, string flatCity, string houseCity, string landCity, string allCity, bool? toLet, AdminSortOption? adminSortOption, bool sortDescAsc)
        {
            var advertsToShow = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_genericRepository.GetSet<Advert>());

            var city = ChooseCities(flatCity, houseCity, landCity, allCity, adType);

            advertsToShow = FilterAdvertsByCity(city, advertsToShow);
            advertsToShow = FilterAdvertsByNumber(number, advertsToShow);
            advertsToShow = FilterHiddenAdverts(showHidden, advertsToShow);
            advertsToShow = FilterAdvertsByDate(dateFrom, dateTo, advertsToShow);
            advertsToShow = FilterAdvertsByPrice(priceFrom, priceTo, advertsToShow);
            advertsToShow = FilterAdvertsByArea(areaFrom, areaTo, advertsToShow);
            advertsToShow = FilterAdvertsByAdvertType(adType, advertsToShow);
            advertsToShow = FilterAdvertsByOfferType(toLet, advertsToShow);

            advertsToShow = _sortAdminService.SortAdverts(advertsToShow, adminSortOption, sortDescAsc);

            return advertsToShow;
        }
        private string ChooseCities(string flatCity, string houseCity, string landCity, string allCity, AdTypeAdmin? adType)
        {
            string city;

            if (adType == AdTypeAdmin.Flat)
            {
                city = flatCity;
            }
            else if (adType == AdTypeAdmin.House)
            {
                city = houseCity;
            }
            else if (adType == AdTypeAdmin.Land)
            {
                city = landCity;
            }
            else
            {
                city = allCity;
            }
            return city;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByCity(string city, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (!String.IsNullOrEmpty(city))
            {
                advertsToShow = advertsToShow.Where(x => x.City == city);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByNumber(string number, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (!String.IsNullOrEmpty(number))
            {
                advertsToShow = advertsToShow.Where(x => x.Number == number);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterHiddenAdverts(bool? showHidden, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (showHidden == false)
            {
                advertsToShow = advertsToShow.Where(x => x.Visible);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByDate(DateTime? dateFrom, DateTime? dateTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (dateFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt.Date >= dateFrom);
            }

            if (dateTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.CreatedAt.Date <= dateTo);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByPrice(int? priceFrom, int? priceTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (priceFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Price >= priceFrom);
            }
            if (priceTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Price <= priceTo);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByArea(int? areaFrom, int? areaTo, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (areaFrom != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Area >= areaFrom);
            }
            if (areaTo != null)
            {
                advertsToShow = advertsToShow.Where(x => x.Area <= areaTo);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByAdvertType(AdTypeAdmin? adType, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if ( adType != AdTypeAdmin.All && adType != null)
            {
                advertsToShow = advertsToShow.Where(x => x.AdType == (AdvertType)adType);
            }
            return advertsToShow;
        }

        private IEnumerable<AdminAdvertToShow> FilterAdvertsByOfferType(bool? toLet, IEnumerable<AdminAdvertToShow> advertsToShow)
        {
            if (toLet != null)
            {
                advertsToShow = advertsToShow.Where(x => x.ToLet == toLet);
            }
            return advertsToShow;
        }

        public IEnumerable<AdminAdvertToShow> ActiveAdverts(AdminSortOption? adminSortOption, bool sortDescAsc)
        {
            var advertsToShow = AutoMapper.Mapper.Map<IEnumerable<AdminAdvertToShow>>(_genericRepository.GetSet<Advert>().Where(x => x.Visible));

            advertsToShow = _sortAdminService.SortAdverts(advertsToShow, adminSortOption, sortDescAsc);

            return advertsToShow;
        }
    }
}