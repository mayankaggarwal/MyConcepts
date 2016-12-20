using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_socialgroup")]
    public class SocialGroup:IEntityBase
    {
        public int GroupID { get; set; }
        public string GroupType { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public Nullable<int> Status { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return GroupID;
            }
            set
            {
                GroupID = (int)value;
            }
        }
    }
}
