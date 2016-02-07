using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DataContractExamples
{
    /// <summary>
    /// This class should not get serialized at constructors with parmaters is available
    /// </summary>
    public class A
    {
        public string field1;
        public A(string field1)
        {
            this.field1 = field1;
        }
    }
}