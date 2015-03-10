using Context;
using Context.Entities;
using Microsoft.Practices.Unity;
using Models.ViewModels;
using Services.CitiesService;
using Services.CitiesService.Implementation;
using Services.CountMessagesAndAdverts;
using Services.CountMessagesAndAdverts.Implementation;
using Services.CRUD.AdvertServices.CreateAdvertService;
using Services.CRUDAdvertServices.CreateAdvertService.Implementation;
using Services.CRUDAdvertServices.ReadAdvertService;
using Services.CRUDAdvertServices.ReadAdvertService.Implementation;
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
using Services.NewestAdvertsService;
using Services.NewestAdvertsService.Implementation;
using Services.PhotoService;
using Services.PhotoService.Implementation;
using Services.ResizeImageService;
using Services.ResizeImageService.Implementation;

namespace NieruchomosciJG.App_Start
{
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
            container.RegisterType<IFilterAdvertService, FilterAdvertService>();
        }
    }
}
