using IDW.Entities.Plazza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Data.Plazza
{
    public class PlazzaUserRelationConfiguration : EntityBaseConfiguration<PlazzaUserRelation>
    {
        public PlazzaUserRelationConfiguration()
        {
            HasKey(e => e.RelationshipID);
        }
    }
}
