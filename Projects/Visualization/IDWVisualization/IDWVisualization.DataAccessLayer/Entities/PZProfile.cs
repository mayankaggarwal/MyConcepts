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
    [Table("tbl_pz_profile")]
    public class PZProfile : IIdentifiableEntity
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Boolean? UserEnabled { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? LastProfileUpdate { get; set; }
        public string UserType { get; set; }
        public Boolean? Visible { get; set; }
        public string Status { get; set; }
        public Boolean? Federated { get; set; }
        public Boolean? NameVisible { get; set; }
        public Boolean? EmailVisible { get; set; }
        public string OrangeEmployeeType { get; set; }
        public string Title { get; set; }
        public string Biography { get; set; }
        public string OrangeEmployeeStatus { get; set; }
        public string Department { get; set; }
        public string CVPaste_Optional { get; set; }
        public string WorkActivities { get; set; }
        public string PhoneNumber { get; set; }
        public string OrangeCUID { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string MyObjectivesAndGoals { get; set; }
        public Boolean? CharterSigned { get; set; }
        public Boolean? DigitalPassport { get; set; }
        public string AlternativePhone { get; set; }
        public string M2AndCommunity { get; set; }
        public string CVPaste { get; set; }
        public string ROICode { get; set; }
        public string BillingCode { get; set; }
        public string Expertise { get; set; }
        public Boolean? Execs { get; set; }
        public string Company { get; set; }
        public string Interests { get; set; }
        public string Schools { get; set; }
        public string Birthday { get; set; }
        public string OrangeAddress { get; set; }
        public string FunFact { get; set; }
        public string Languages { get; set; }
        public Boolean? GIRStatus { get; set; }
        public DateTime? GIRBirthdate { get; set; }
        public long Points { get; set; }

        [NotMapped]
        public int EntityId
        {
            get
            {
                return UserID;
            }
            set
            {
                UserID = value;
            }
        }
    }
}
