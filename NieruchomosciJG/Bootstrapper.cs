﻿using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NieruchomosciJG.App_Start;
using Unity.Mvc4;

namespace NieruchomosciJG
{
  public static class Bootstrapper
  {
      public static IUnityContainer Initialise()
      {
          var container = BuildUnityContainer();

          DependencyResolver.SetResolver(new UnityDependencyResolver(container));
          GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);


          return container;
      }

      private static IUnityContainer BuildUnityContainer()
      {
          var container = new UnityContainer();
          UnityConfig.RegisterTypes(container);

          return container;
      }
  }
}