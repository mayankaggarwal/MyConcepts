﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using IDW.WebApp.App_Start;
using System.Web.Optimization;

namespace IDW.WebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);            

            var config = GlobalConfiguration.Configuration;
            AreaRegistration.RegisterAllAreas(); 
            WebApiConfig.Register(config); 
            Bootstrapper.Run(); 
            RouteConfig.RegisterRoutes(RouteTable.Routes); 
            GlobalConfiguration.Configuration.EnsureInitialized(); 
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}