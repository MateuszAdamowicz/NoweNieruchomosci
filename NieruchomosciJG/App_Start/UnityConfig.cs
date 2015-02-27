using Context;
using Context.Entities;
using Microsoft.Practices.Unity;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;
using Services.GetAvailableAdvertTypes;
using Services.GetPropertiesByAdvertType;
using Services.GetPropertiesByAdvertType.Implementation;
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
            container.RegisterType<IGetPropertiesByAdvertType, GetPropertiesByAdvertType>();
            container.RegisterType<IPhotoService, PhotoService>();
            container.RegisterType<IResizeImageService, ResizeImageService>();
            container.RegisterType<IGetAvailableAdvertTypes, IGetAvailableAdvertTypes>();
        }
    }
}
