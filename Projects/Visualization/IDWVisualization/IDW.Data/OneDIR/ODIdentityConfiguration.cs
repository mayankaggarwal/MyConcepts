using IDW.Entities.OneDIR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.OneDIR
{
    public class ODIdentityConfiguration : EntityBaseConfiguration<OD_Identity>
    {
        public ODIdentityConfiguration()
        {
            HasKey(e => e.CUID);
        }
    }
}
