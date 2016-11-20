using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Dependancy;
using Microsoft.Practices.Unity;

namespace BusTickets
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // GlobalConfiguration.Configuration.DependencyResolver = new BTDependancyResolver(container);
           
            DependencyResolver.SetResolver(
                new BTDependancyResolver(container));           

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}