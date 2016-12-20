using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_groupmember")]
    public class PlazzaGroupMember:IEntityBase
    {
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public string MemberType { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> MembershipID { get; set; }
        public Nullable<System.DateTime> MemberDate { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return GroupID;
            }
            set
            {
                this.GroupID = (int)value;
            }
        }
    }
}
