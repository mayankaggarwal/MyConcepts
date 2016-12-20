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
    [Table("tbl_pz_socialgroup")]
    public class SocialGroup : IIdentifiableEntity
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupType { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int OwnerID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int Status { get; set; }

        [NotMapped]
        public int EntityId
        {
            get
            {
                return GroupID;
            }
            set
            {
                GroupID = value;
            }
        }
    }
}
