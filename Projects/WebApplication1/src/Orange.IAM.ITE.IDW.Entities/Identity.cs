using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orange.IAM.ITE.IDW.Entities
{
    public class Identity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String Organization { get; set; }
        public String GirDomain { get; set; }
        public String ManagerCUID { get; set; }
        public String DisplayName { get; set; }
        public String custom1 { get; set; }
        public String custom2 { get; set; }
        public String custom3 { get; set; }
        public String custom4 { get; set; }
        public String custom5 { get; set; }
        public int Profile { get; set; }
        public String EmployeeType { get; set; }
        public String MainEmailAddress { get; set; }
        public String PhysicalAddress { get; set; }
        public TitleValues title { get; set; }
        public String PreferredFirstName { get; set; }
        public String MiddleName { get; set; }
        public String PreferredLastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public String SecondaryEmailAddress { get; set; }
        public String LocalID { get; set; }
        public String EmployeeNumber { get; set; }
        public String Description { get; set; }
        public String PartnerCode { get; set; }
        public String SubsidiaryCode { get; set; }
        public String MobilePhoneNumber { get; set; }
        public String PhoneNumber { get; set; }
        public String HRStatus { get; set; }
        public String JobFunction { get; set; }
        public String Entity { get; set; }
        public String HRManager { get; set; }
        public String NotificationMail { get; set; }
        public bool ReportingGlobalEnabled { get; set; }
    }

    public enum TitleValues
    {

        /// <remarks/>
        UNKNOWN=0,

        /// <remarks/>
        MR=1,

        /// <remarks/>
        MRS=2,

        /// <remarks/>
        MISS=3,
    }
}
