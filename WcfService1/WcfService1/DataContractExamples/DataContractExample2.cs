using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    public interface ICustomerInfo
    {
        string ReturnCustomerName();
    }

    [DataContract(Name = "Customer")]
    public class CustomerTypeA : ICustomerInfo
    {
        public string ReturnCustomerName()
        {
            return "Customer Type B";
        }
    }

    [DataContract(Name = "Customer")]
    public class CustomerTypeB : ICustomerInfo
    {
        public string ReturnCustomerName()
        {
            return "Customer Type B";
        }
    }

    /// <summary>
    /// In the following example, even though both CustomerTypeA and CustomerTypeB have the Customer data contract, 
    /// an instance of CustomerTypeB is created whenever a PurchaseOrder is deserialized, 
    /// because only CustomerTypeB is known to the deserialization engine.
    /// </summary>
    [DataContract(Name = "PurchaseOrder")]
    [KnownType(typeof(CustomerTypeB))]
    public class PurchaseOrder
    {
        [DataMember]
        ICustomerInfo buyer;

        [DataMember]
        int amount;
    }
}