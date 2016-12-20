using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Membership
{
    [Table("tbl_Membership_Role")]
    public class Role : IEntityBase
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
    }
}
