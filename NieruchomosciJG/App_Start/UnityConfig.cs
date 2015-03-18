using System.Diagnostics.CodeAnalysis;
using Context;
using Context.Entities;
using Microsoft.Practices.Unity;
using Models.ViewModels;
using RazorEngine;
using RazorEngine.Templating;
using Services.AdminLoginService;
using Services.AdminLoginService.Implementation;
using Services.AdvertSearchOptionsService;
using Services.AdvertSearchOptionsService.Implementation;
using Services.AdvertSortEnginesService;
using Services.AdvertSortEnginesService.Implementation;
using Services.AdvertSortEnginesService.Implementation.Engines;
using Services.ApplicationSettingsService;
using Services.ApplicationSettingsService.Implementation;
using Services.CitiesService;
using Services.CitiesService.Implementation;
using Services.CountMessagesAndAdverts;
using Services.CountMessagesAndAdverts.Implementation;
using Services.CRUDAdvertServices.CreateAdvertService;
using Services.CRUDAdvertServices.CreateAdvertService.Implementation;
using Services.CRUDAdvertServices.DeleteAdvertService;
using Services.CRUDAdvertServices.DeleteAdvertService.Implementation;
using Services.CRUDAdvertServices.ReadAdvertService;
using Services.CRUDAdvertServices.ReadAdvertService.Implementation;
using Services.CRUDAdvertServices.UpdateAdvertService;
using Services.CRUDAdvertServices.UpdateAdvertService.Implementation;
using Services.DetailedSortService;
using Services.DetailedSortService.Implementation;
using Services.DetailedSortService.Implementation.Engines;
using Services.EmailServices.EmailRepository;
using Services.EmailServices.EmailRepository.Implementation;
using Services.EmailServices.ParseEmailService;
using Services.EmailServices.ParseEmailService.Implementation;
using Services.EmailServices.SaveEmailService;
using Services.EmailServices.SaveEmailService.Implementation;
using Services.EmailServices.SmtpManager;
using Services.EmailServices.SmtpManager.Implementation;
using Services.EmailServices.TemplateRepository;
using Services.EmailServices.TemplateRepository.Implementation;
using Services.FilterAdvertService;
using Services.FilterAdvertService.Implementation;
using Services.FilterOptionService;
using Services.FilterOptionService.Implementation;
using Services.FindPhotosById;
using Services.FindPhotosById.Implementation;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;
using Services.GetAdvertTypes;
using Services.GetAdvertTypes.Implementation;
using Services.GetPropertiesByAdvertType;
using Services.GetPropertiesByAdvertType.Implementation;
using Services.MessageSerivce;
using Services.MessageSerivce.Implementation;
using Services.NewestAdvertsService;
using Services.NewestAdvertsService.Implementation;
using Services.PhotoService;
using Services.PhotoService.Implementation;
using Services.ResizeImageService;
using Services.ResizeImageService.Implementation;
using Services.SearchAdvertService;
using Services.SearchAdvertService.Implementation;
using Services.SortAdvertService;
using Services.SortAdvertService.Implementation;

namespace NieruchomosciJG.App_Start
{
    [ExcludeFromCodeCoverage]
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<INieruchomosciContext, NieruchomosciContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<Advert>, GenericRepository<Advert>>();
            container.RegisterType<IGenericRepository<Photo>, GenericRepository<Photo>>();
            container.RegisterType<IGenericRepository<Message>, GenericRepository<Message>>();
            container.RegisterType<IGenericRepository<Property>, GenericRepository<Property>>();
            container.RegisterType<IGenericRepository<PropertyDictionary>, GenericRepository<PropertyDictionary>>();
            container.RegisterType<IGenericRepository<AdvertType>, GenericRepository<AdvertType>>();
            container.RegisterType<IGetPropertiesByAdvertType, GetPropertiesByAdvertType>();
            container.RegisterType<IPhotoService, PhotoService>();
            container.RegisterType<IResizeImageService, ResizeImageService>();
            container.RegisterType<IGetAdvertTypes, GetAdvertTypes>();
            container.RegisterType<ICreateAdvertService, CreateAdvertService>();
            container.RegisterType<IFindPhotosByIdService, FindPhotosByIdService>();
            container.RegisterType<INewestAdvertsService, NewestAdvertsService>();
            container.RegisterType<ICitiesService, CitiesService>(); 
            container.RegisterType<ICountMessagesAndAdverts, CountMessagesAndAdverts>();
            container.RegisterType<IFilterOptionService, FilterOptionService>();
            container.RegisterType<IReadAdvertService, ReadAdvertService>();
            container.RegisterType<IAdvertSearchOptionService, AdvertSearchOptionService>();
            container.RegisterType<ISearchAdvertService, SearchAdvertService>();
            container.RegisterType<IFilterAdvertService, FilterAdvertService>();
            container.RegisterType<ISortAdvertService, SortAdvertService>();
            container.RegisterType<IApplicationSettingsService, ApplicationSettingsService>();
            container.RegisterType<IEmailRepository, EmailRepository>();
            container.RegisterType<IParseEmailService, ParseEmailService>();
            container.RegisterType<ISaveEmailService, SaveEmailService>();
            container.RegisterType<ISmtpManager, SmtpManager>();
            container.RegisterType<ITemplateRepository, TemplateRepository>();
            container.RegisterType<IUpdateAdvertService, UpdateAdvertService>();
            container.RegisterType<IDeleteAdvertService, DeleteAdvertService>();
            container.RegisterType<IAdvertSortEnginesService, AdvertSortEnginesService>();
            container.RegisterType<IDetailedSortService, IDetailedSortService>();
            container.RegisterType<IAdminLoginService, AdminLoginService>();

            container.RegisterType<ISortCityAscEngine, SortCityAscEngine>();
            container.RegisterType<ISortCityDescEngine, SortCityDescEngine>();
            container.RegisterType<ISortDateAscEngine, SortDateAscEngine>();
            container.RegisterType<ISortDateDescEngine, SortDateDescEngine>();
            container.RegisterType<ISortPriceAscEngine, SortPriceAscEngine>();
            container.RegisterType<ISortPriceDescEngine, SortPriceDescEngine>();

            container.RegisterType<IDetailedSortAdType, DetailedSortAdType>();
            container.RegisterType<IDetailedSortArea, DetailedSortArea>();
            container.RegisterType<IDetailedSortCity, DetailedSortCity>();
            container.RegisterType<IDetailedSortCreatedAt, DetailedSortCreatedAt>();
            container.RegisterType<IDetailedSortNumber, DetailedSortNumber>();
            container.RegisterType<IDetailedSortPrice, DetailedSortPrice>();
            container.RegisterType<IDetailedSortToLet, DetailedSortToLet>();
            container.RegisterType<IDetailedSortVisible, DetailedSortVisible>();

            container.RegisterType<IDetailedSortService, DetailedSortService>();

            container.RegisterType<IMessageService, MessageService>();
        }
    }
}
