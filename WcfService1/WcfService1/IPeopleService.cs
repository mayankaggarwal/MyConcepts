using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPeopleService" in both code and config file together.
    [ServiceContract]
    public interface IPeopleService
    {

        [OperationContract]
        string GetData(int value);
    }


}
