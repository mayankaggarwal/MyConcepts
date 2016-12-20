using IDW.Entities.Plazza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.Plazza
{
    public class SocialGroupConfiguration : EntityBaseConfiguration<SocialGroup>
    {
        public SocialGroupConfiguration()
        {
            HasKey(e => e.GroupID);
        }
    }
}
