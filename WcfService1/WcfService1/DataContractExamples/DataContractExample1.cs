using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class Shape { }

    [DataContract]
    public class CircularShape : Shape { }

    [DataContract]
    public class TriangularShape : Shape { }

    /// <summary>
    /// The company class can be serialized but without known types of Circular shape and Triangular shape it
    /// can be desrialized
    /// </summary>
    [DataContract]
    [KnownType(typeof(CircularShape))]
    [KnownType(typeof(TriangularShape))]
    public class CompanyLogo
    {
        [DataMember]
        public Shape ShapeOfLogo;
        [DataMember]
        public int ColorOfLogo;
    }
}