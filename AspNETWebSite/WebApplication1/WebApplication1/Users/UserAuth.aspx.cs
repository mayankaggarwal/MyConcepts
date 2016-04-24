using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            BadCredentials.Visible = false;
            string[] userNames = { "Mayank", "ScottGu", "Santosh", "Mohit" };
            string[] passwords = { "mayank", "scottgu", "santosh", "mohit" };

            for(int i=0;i<userNames.Length;i++)
            {
                bool isUserNameValid = (String.Compare(UserName.Text, userNames[i], true) == 0);
                bool isPasswordValid = (String.Compare(Password.Text, passwords[i], false) == 0);
                if (isUserNameValid && isPasswordValid)
                    FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
            }
            
            BadCredentials.Visible = true;
        }
    }
}