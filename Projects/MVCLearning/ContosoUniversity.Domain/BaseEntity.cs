using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Domain
{
    public class BaseEntity:IBaseEntity
    {
        public object ID { get; set; }
    }
}
