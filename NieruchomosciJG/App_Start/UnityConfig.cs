using System;
using System.Runtime.InteropServices.ComTypes;
using Context;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Services.AdminIndexService.AdminFilterAdvertService;
using Services.AdminIndexService.AdminFilterAdvertService.Implementation;
using Services.AdminIndexService.AdminFilterOptionsService;
using Services.AdminIndexService.AdminFilterOptionsService.Implementation;
using Services.EnumNameService.Implementation;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;
using Services.AdminMenuServices;
using Services.AdminMenuServices.Implementation;
using Services.SortService.SortAdminService;
using Services.SortService.SortAdminService.Implementation;

namespace NieruchomosciJG.App_Start
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<INieruchomosciContext, NieruchomosciContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository, GenericRepository>();
            container.RegisterType<IAdminMenuService, AdminMenuService>();
            container.RegisterType<IAdminFilterOptionsService, AdminFilterOptionsService>();
            container.RegisterType<IAdminFilterAdvertService, AdminFilterAdvertService>();
            container.RegisterType<ISortAdminService, SortAdminService>();
            container.RegisterType<IEnumNameService, EnumNameService>();
        }
    }
}
