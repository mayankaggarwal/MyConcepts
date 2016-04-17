using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PeopleService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PeopleService.svc or PeopleService.svc.cs at the Solution Explorer and start debugging.
    public class PeopleService : IPeopleService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
