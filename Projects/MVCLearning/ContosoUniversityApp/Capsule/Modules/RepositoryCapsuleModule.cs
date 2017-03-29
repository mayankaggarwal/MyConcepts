using Autofac;
using ContosoUniversity.Data;
using ContosoUniversity.Repository;
using ContosoUniversityApp.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityApp.Capsule.Modules
{
    public class RepositoryCapsuleModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ReferencedAssemblies.Repositories).
                Where(_ => _.Name.EndsWith("Repository")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(DataRepository<>)).As(typeof(IDataRepository<>)).InstancePerDependency();
        }
    }
}