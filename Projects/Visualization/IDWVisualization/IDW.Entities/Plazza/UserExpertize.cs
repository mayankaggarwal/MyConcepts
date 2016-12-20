using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_expertise")]
    public class UserExpertize : IEntityBase
    {
        public int ExpertiseTagID { get; set; }
        public int TagID { get; set; }
        public int TargetUserID { get; set; }
        public int OriginUserID { get; set; }
        public bool Approved { get; set; }
        public Nullable<DateTime> ExpertiseCreationDate { get; set; }
        public string TagName { get; set; }
        public Nullable<DateTime> TagCreationDate { get; set; }

        [NotMapped]
        public long ID
        {
            get
            {
                return ExpertiseTagID;
            }
            set
            {
                this.ExpertiseTagID = (int)value;
            }
        }
    }
}
