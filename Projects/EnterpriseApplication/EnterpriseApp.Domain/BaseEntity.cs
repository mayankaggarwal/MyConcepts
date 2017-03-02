using EnterpriseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Models
{
    public class BaseEntity : IBaseEntity
    {
        public object ID { get; set; }
    }
}
