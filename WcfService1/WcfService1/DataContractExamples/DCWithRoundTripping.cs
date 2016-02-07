using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Person : IExtensibleDataObject
    {
        [DataMember]
        public string FullName;

        public ExtensionDataObject theData;

        public virtual ExtensionDataObject ExtensionData
        {
            get { return this.theData; }

            set { this.theData = value; }
        }
    }
}