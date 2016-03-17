using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CSharpConcepts.ArticlesExamples
{
    public class DeepCloneExample:IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Deep Clone/Copy example");
        }

        public void MainMethod()
        {
            Console.WriteLine("Class implemented but but still not utilized------------------------------");
        }
    }

    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            if(!typeof(T).IsSerializable)
            {
                throw new ArgumentException("This must be serializable.", "source");
            }

            if(Object.ReferenceEquals(source,null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using(stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
