using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace IDW.WebApp.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebAPIConfig.Initialize(GlobalConfiguration.Configuration);
            //Configure AutoMapper 
            AutoMapperConfiguration.Configure(); 
        }
    }
}