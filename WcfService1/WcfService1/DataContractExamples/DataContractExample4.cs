using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.DataContractExamples
{
    /// <summary>
    /// The theDrawing field contains instances of a generic class ColorDrawing and a generic class BlackAndWhiteDrawing, 
    /// both of which inherit from a generic class Drawing. 
    /// Normally, both must be added to known types, but the following is not valid syntax for attributes.
    /// 
    /// // Invalid syntax for attributes:
    /// //[KnownType(typeof(ColorDrawing<T>))]
    /// //[KnownType(typeof(BlackAndWhiteDrawing<T>))]
    /// 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    [KnownType("GetKnownType")]
    public class DrawingRecord<T>
    {
        [DataMember]
        private T theData;
        [DataMember]
        private Drawing<T> theDrawing;

        private static Type[] GetKnownType()
        {
            Type[] t = new Type[2];
            t[0] = typeof(ColorDrawing<T>);
            t[1] = typeof(BlackAndWhiteDrawing<T>);
            return t;
        }
    }

    public class Drawing<T> { }
    public class ColorDrawing<T> : Drawing<T> { }
    public class BlackAndWhiteDrawing<T> : Drawing<T> { }
}