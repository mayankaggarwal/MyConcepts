using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using IDW.Entities;

namespace IDW.Data
{
    public class EntityBaseConfiguration<T>:EntityTypeConfiguration<T> where T:class,IEntityBase
    {
        public EntityBaseConfiguration()
        {

        }
    }
}
