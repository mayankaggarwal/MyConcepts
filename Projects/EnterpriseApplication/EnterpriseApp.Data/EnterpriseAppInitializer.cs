using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EnterpriseApp.Data
{
    public class EnterpriseAppInitializer : DropCreateDatabaseIfModelChanges<EnterpriseAppDbContext>
    {
    }
}
