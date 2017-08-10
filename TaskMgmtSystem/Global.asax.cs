using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskMgmtSystem.Migrations;
using TaskMgmtSystem.Models;

namespace TaskMgmtSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //var context = new ApplicationDbContext();
            //context.Database.Initialize(true); //If set to true the initializer is run even if it has already been run.       
            //context.Database.Create();
        }
    }
}
