using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Domain
{
    interface IBaseEntity
    {
        object ID { get; set; }
    }
}
