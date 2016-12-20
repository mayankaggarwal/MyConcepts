using ExpenseManagerWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpenseManagerWebApp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ExpenseManagerMembershipProvider membershipProvider = new ExpenseManagerMembershipProvider();
                MembershipCreateStatus membershipStatus;
                MembershipUser user = membershipProvider.CreateUser(UserName.Text, Password.Text, Email.Text, string.Empty, string.Empty, true, null, out membershipStatus);
                if(membershipStatus == MembershipCreateStatus.Success)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    ErrorMessage.Text = membershipStatus.ToString();
                }
            }

            //var manager = new UserManager();
            //var user = new ApplicationUser() { UserName = UserName.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    IdentityHelper.SignIn(manager, user, isPersistent: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}