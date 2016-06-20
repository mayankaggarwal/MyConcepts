using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    class UserNamePassValidator : System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "mayank" && password == "Admin123+"))
            {
                throw new FaultException("Incorrect Username or Password");
            }
        }
    }
}
