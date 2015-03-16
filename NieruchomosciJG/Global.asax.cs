using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using log4net;
using log4net.Config;
using NieruchomosciJG.App_Start;

namespace NieruchomosciJG
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            ILog logger = LogManager.GetLogger("Log4NetTest.OtherClass");
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, logger);          
            MapperConfig.Register();
            Bootstrapper.Initialise();

        }
    }
}