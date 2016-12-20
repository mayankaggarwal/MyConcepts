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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            //ExpenseManagerMembershipProvider membershipProvider = new ExpenseManagerMembershipProvider();
            //if(membershipProvider.ValidateUser(UserName.Text.Trim(),Password.Text))
            //{
            if(Membership.ValidateUser(UserName.Text.Trim(),Password.Text))
            {
                //FormsAuthentication.SetAuthCookie(UserName.Text.Trim(), false);

                //FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket(1,
                //    UserName.Text.Trim(),
                //    DateTime.Now, DateTime.Now.AddMinutes(10),
                //    false,
                //    string.Empty);

                //HttpCookie cookie = new HttpCookie(
                //    FormsAuthentication.FormsCookieName,
                //    FormsAuthentication.Encrypt(ticket1));

                //Response.Cookies.Add(cookie);

                //if(Request.QueryString["ReturnUrl"]==null)
                //{
                //    Response.Redirect("~/default.aspx");
                //}
                //else
                //{
                //    throw new Exception("To implement");
                //}
                FormsAuthentication.RedirectFromLoginPage(UserName.Text.Trim(), RememberMe.Checked);

            }
        }
    }
}