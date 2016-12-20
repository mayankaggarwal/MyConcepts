using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_community")]
    public class PlazzaCommunity:IEntityBase
    {
        public int CommunityID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return CommunityID;
            }
            set
            {
                this.CommunityID = (int)value;
            }
        }
    }
}
