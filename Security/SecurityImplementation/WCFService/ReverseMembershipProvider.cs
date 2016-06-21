using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace WCFService
{
    public class ReverseMembershipProvider: SqlMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            bool validated = false;
            try
            {
                MembershipProvider provider = Membership.Providers["DefaultMembershipProvider"];
                if (provider.ApplicationName == "MyApplication")
                {
                    throw new Exception("Application problem !!!!");   // HERE'S EXCEPTION
                }
                //bool validated = provider.ValidateUser(username, password);
                MembershipCreateStatus createStatus = new MembershipCreateStatus();
                MembershipUser usr = Membership.CreateUser("latika", "latika@123", "latika@gmail.com", "my userName is", "latika", true, null, out createStatus);
                string pass1 = this.PasswordFormat.ToString();
                string pass = this.GetPassword("ma", "latika");

            }
            catch(Exception exp)
            {

            }
            return validated;
        }
    }
}
