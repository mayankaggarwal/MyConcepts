using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ContosoUniversityApp.References
{
    public static class ReferencedAssemblies
    {
        public static Assembly Services
        {
            get { return Assembly.Load("ContosoUniversity.Services"); }
        }

        public static Assembly Repositories
        {
            get { return Assembly.Load("ContosoUniversity.Data"); }
        }

        public static Assembly Domain
        {
            get { return Assembly.Load("ContosoUniversity.Domain"); }
        }

        public static Assembly RepositoryInterfaces
        {
            get { return Assembly.Load("ContosoUniversity.Repository"); }
        }

        public static Assembly ServiceInterfaces
        {
            get { return Assembly.Load("ContosoUniversity.Core"); }
        }
    }
}