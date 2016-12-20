using IDW.Entities.GIR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.GIR
{
    public class GIRIdentityConfiguration:EntityBaseConfiguration<GIR_Identity>
    {
        public GIRIdentityConfiguration()
        {
            HasKey(e => e.CUID);
        }
    }
}
