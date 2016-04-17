using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        // This is not serialized, but the property is.
        bool boolValue = true;
        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        // This is not serialized, but the property is.
        string stringValue = "Hello ";
        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value + "10"; }
        }

        // This member is serialized.
        [DataMember]
        internal string FullName = "Mayank Aggarwal";

        // This is serialized even though it is private.
        [DataMember]
        private int Age;

        // This is not serialized because the DataMemberAttribute 
        // has not been applied.
        private string MailingAddress;

        // This is not serialized, but the property is.
        private string telephoneNumberValue;

        [DataMember]
        public string TelephoneNumber
        {
            get { return telephoneNumberValue; }
            set { telephoneNumberValue = value; }
        }

        [DataMember]
        public static string fieldStatic;

        public string fieldPublic;

        public CompositeType()
        {
            fieldPublic = "Public";
            StringValue = StringValue + "Constructor";
        }

    }

}
