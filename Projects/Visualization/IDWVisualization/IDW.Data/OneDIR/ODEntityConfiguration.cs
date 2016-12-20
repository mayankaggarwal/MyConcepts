using IDW.Entities.OneDIR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.OneDIR
{
    public class ODEntityConfiguration : EntityBaseConfiguration<OD_Entity>
    {
        public ODEntityConfiguration()
        {
            HasKey(e => e.Entity);
        }
    }
}
