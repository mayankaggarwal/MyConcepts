using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1
{
    [ServiceContract]
    public interface IAnotherInterfaceService
    {
        [OperationContract]
        string GetEmployeeID(int id);
    }
}
