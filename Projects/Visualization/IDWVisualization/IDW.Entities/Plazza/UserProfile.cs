using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDW.Entities.Plazza
{
    [Table("tbl_pz_profile")]
    public class UserProfile : IEntityBase
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Nullable<bool> UserEnabled { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<short> CreationMonth { get; set; }
        public Nullable<short> CreationYear { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public Nullable<short> ModificationMonth { get; set; }
        public Nullable<short> ModificationYear { get; set; }
        public Nullable<System.DateTime> LastLoggedIn { get; set; }
        public Nullable<short> LastLoggedInMonth { get; set; }
        public Nullable<short> LastLoggedInYear { get; set; }
        public Nullable<System.DateTime> LastProfileUpdate { get; set; }
        public Nullable<short> LastProfileUpdateMonth { get; set; }
        public Nullable<short> LastProfileUpdateYear { get; set; }
        public string UserType { get; set; }
        public Nullable<bool> Visible { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Federated { get; set; }
        public Nullable<bool> NameVisible { get; set; }
        public Nullable<bool> EmailVisible { get; set; }
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
        public Nullable<bool> CharterSigned { get; set; }
        public Nullable<bool> DigitalPassport { get; set; }
        public string AlternativePhone { get; set; }
        public string M2AndCommunity { get; set; }
        public string CVPaste { get; set; }
        public string ROICode { get; set; }
        public string BillingCode { get; set; }
        public string Expertise { get; set; }
        public Nullable<bool> Execs { get; set; }
        public string Company { get; set; }
        public string Interests { get; set; }
        public string Schools { get; set; }
        public string Birthday { get; set; }
        public string OrangeAddress { get; set; }
        public string FunFact { get; set; }
        public string Languages { get; set; }
        public Nullable<bool> GIRStatus { get; set; }
        public Nullable<System.DateTime> GIRBirthdate { get; set; }
        public Nullable<long> Points { get; set; }

        [NotMapped]
        public long ID
        {
            get
            {
                return UserID;
            }
            set
            {
                UserID = (int)value;
            }
        }
    }
}
