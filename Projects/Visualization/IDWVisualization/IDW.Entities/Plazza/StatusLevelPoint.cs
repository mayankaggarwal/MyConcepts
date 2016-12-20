using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_statuslevelpoint")]
    public class StatusLevelPoint:IEntityBase
    {
        [Key]
        public int PointID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<long> ContainerTypeCode { get; set; }
        public string ContainerType { get; set; }
        public Nullable<int> ContainerID { get; set; }
        public Nullable<int> Points { get; set; }
        public Nullable<long> ObjectTypeCode { get; set; }
        public string ObjectType { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return PointID;
            }
            set
            {
                this.PointID = (int)value;
            }
        }
    }
}
