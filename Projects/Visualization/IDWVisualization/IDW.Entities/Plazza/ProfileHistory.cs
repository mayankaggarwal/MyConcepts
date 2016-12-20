using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_profile_his")]
    public class ProfileHistory:IEntityBase
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Modified { get; set; }
        public Nullable<bool> Logged { get; set; }
        public Nullable<bool> ProfileUpdated { get; set; }
        public Nullable<long> Points { get; set; }
        public string Department { get; set; }
        public string Month_His { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return UserID;
            }
            set
            {
                this.UserID = (int)value;
            }
        }
    }
}
