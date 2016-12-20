using IDWVisualization.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.Entities
{
    [Table("tbl_pz_activity")]
    public class PZActivity : IIdentifiableEntity
    {
        [Key]
        public Int64 ActivityID { get; set; }
        public string ActivityType { get; set; }
        public Int64 ObjectTypeCode { get; set; }
        public string ObjectType { get; set; }
        public int ObjectID { get; set; }
        public Int64 ContainerTypeCode { get; set; }
        public string ContainerType { get; set; }
        public int ContainerID { get; set; }
        public int UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public Int16 CreationMonth { get; set; }
        public Int16 CreationYear { get; set; }

        [NotMapped]
        public Int32 EntityId
        {
            get
            {
                return (int)ActivityID;
            }
            set
            {
                ActivityID = value;
            }
        }
    }
}
