using IDW.Entities.Plazza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.Plazza
{
    public class ProjectDetailsConfiguration : EntityBaseConfiguration<ProjectDetails>
    {
        public ProjectDetailsConfiguration()
        {
            HasKey(e => e.ProjectID);
        }
    }
}
