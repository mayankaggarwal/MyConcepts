using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    /// <summary>
    /// When a known type is associated with a particular type using the KnownTypeAttribute attribute, 
    /// the known type is also associated with all of the derived types of that type.
    /// </summary>
    [DataContract]
    [KnownType(typeof(Square))]
    [KnownType(typeof(Circle))]
    public class MyDrawing
    {
        [DataMember]
        private object Shape;
        [DataMember]
        private int Color;
    }

    [DataContract]
    public class DoubleDrawing : MyDrawing
    {
        [DataMember]
        private object additionalShape;
    }

    internal class Circle
    {
    }

    internal class Square
    {
    }
}