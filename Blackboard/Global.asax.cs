using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;
using Blackboard.Models;
using System.Data.Entity;
using MVC1.Models;


namespace Blackboard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<CollegeContext>(new CollegeInitializer());
            Console.Out.WriteLine(this);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebSecurity.InitializeDatabaseConnection("DefaultConnection","UserProfile","UserId","Username",true);
        }
    }
}
