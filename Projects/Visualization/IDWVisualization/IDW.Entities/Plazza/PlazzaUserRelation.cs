using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_userrelation")]
    public class PlazzaUserRelation : IEntityBase
    {
        public int RelationshipID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> RelatedUserID { get; set; }
        public Nullable<int> RelnshipTypeID { get; set; }
        public string State { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> RetirementDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        [NotMapped]
        public long ID
        {
            get
            {
                return RelationshipID;
            }
            set
            {
                this.RelationshipID = (int)value;
            }
        }
    }
}
