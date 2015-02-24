using System;
using Context;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;

namespace NieruchomosciJG.App_Start
{
    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<INieruchomosciContext, NieruchomosciContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository, GenericRepository>();
        }
    }
}
