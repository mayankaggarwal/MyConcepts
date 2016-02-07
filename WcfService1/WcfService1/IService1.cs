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

        [OperationContract]
        ClassWithoutDC GetDataWithoutUsingDataContract(ClassWithoutDC cwdc);
        // TODO: Add your service operations here

        //Gives error as ClassInternal is less accessible
        //[OperationContract]
        //ClassInternal GetDataClassInternal(ClassInternal internalClass);
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

    // This class will be serializable
    public class ClassWithoutDC
    {
        //This member will be serializable;
        public string field1;

        //This field will be serialized
        public string field2;

        //This field should not be serialized
        [DataMember]
        public string fieldDataMember;

        //This field will not be serialized
        private string fieldPrivate;

        //This field will not be serialized
        public static string fieldStatic;

        //This field will not be serialized
        [IgnoreDataMember]
        public string fieldIgnore;
    }

    internal class ClassInternal
    {
        internal string fieldInternal;
    }
}
