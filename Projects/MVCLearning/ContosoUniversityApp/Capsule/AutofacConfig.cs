using Autofac;
using Autofac.Integration.Mvc;
using ContosoUniversity.Data;
using ContosoUniversity.Repository;
using ContosoUniversityApp.Capsule.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversityApp.Capsule
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterFilterProvider();

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();

            const string nameOrConnectionString = "name=ContosoUniversityDbConnection";
            builder.Register<IDbContext>(b =>
            {
                var context = new ContosoUniversityDbContext(nameOrConnectionString);
                return context;
            }).InstancePerLifetimeScope();

            builder.RegisterModule<RepositoryCapsuleModule>();
            builder.RegisterModule<ServiceCapsuleModule>();
            builder.RegisterModule<ControllerCapsuleModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           

            // Register dependencies in controllers
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //// Register dependencies in filter attributes
            //builder.RegisterFilterProvider();

            //// Register dependencies in custom views
            //builder.RegisterSource(new ViewRegistrationSource());

            //// Register our Data dependencies
            //builder.RegisterModule(new DataModule("MVCWithAutofacDB"));

            //var container = builder.Build();

            //// Set MVC DI resolver to use our Autofac container
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}