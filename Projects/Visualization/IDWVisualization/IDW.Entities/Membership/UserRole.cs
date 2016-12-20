using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Membership
{
    public class UserRole:IEntityBase
    {
        public Int64 ID { get; set; } 
        public int UserId { get; set; } 
        public int RoleId { get; set; } 
        public virtual Role Role { get; set; }
    }
}
