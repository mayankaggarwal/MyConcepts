using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string Street;

        [DataMember]
        public string State;

        // This data member was added in version 2, and thus may be missing 
        // in the incoming data if the data conforms to version 1 of the 
        // Data Contract. Use the callback to add a default for this case.
        [DataMember(Order = 2)]
        public string CountryRegion;

        // This method is used as a kind of constructor to initialize
        // a default value for the CountryRegion data member before 
        // deserialization
        [OnDeserializing]
        private void setDefaultCountryRegion(StreamingContext c)
        {
            CountryRegion = "India";
        }
    }
}