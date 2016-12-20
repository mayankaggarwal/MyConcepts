using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_activity")]
    public class UserActivity:IEntityBase
    {
        public long ActivityID { get; set; }
        public string ActivityType { get; set; }
        public Nullable<long> ObjectTypeCode { get; set; }
        public string ObjectType { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public Nullable<long> ContainerTypeCode { get; set; }
        public string ContainerType { get; set; }
        public Nullable<int> ContainerID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<short> CreationMonth { get; set; }
        public Nullable<short> CreationYear { get; set; }

        [NotMapped]
        public long ID
        {
            get
            {
                return ActivityID;
            }
            set
            {
                ActivityID = value;
            }
        }
    }
}
