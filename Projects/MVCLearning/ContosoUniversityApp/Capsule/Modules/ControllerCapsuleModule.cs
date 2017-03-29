using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;

namespace ContosoUniversityApp.Capsule.Modules
{
    public class ControllerCapsuleModule:Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.Load("ContosoUniversityApp"));
        }
    }
}