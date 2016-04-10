using System;
using CSharpConcepts.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace CSharpConcepts.DataAccessConcepts
{
    public class SerializationAndDeserializationExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Serialization and DeSerialization Examples");
            Console.WriteLine(".Net framework offers three seralization mechanisms that we use by default:");
            Console.WriteLine("1. Xml Serialization \n 2. Binary Serialization \n 3. DataContract Serialization");
        }

        public void MainMethod()
        {
            SimpleXmlSerializationExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            XmlSerializationwithManiputationUsingAttributes();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            SimpleBinarySerializationExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            InfluenciingBinarySerializationAndDeserialiation();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            ImplementingISerialization();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingDataContractSerialiation();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingJSONSerializationExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }

        private void SimpleXmlSerializationExample()
        {
            Console.WriteLine("Simple Xml Serialization Example");
            Console.WriteLine("Serializing XML using XmlSerializer:");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Person person = new Person()
                {
                    FirstName = "Mayank",
                    LastName = "Aggarwal",
                    Age = (DateTime.Now.Year - 1989)
                };

                xmlSerializer.Serialize(stringWriter, person);
                xml = stringWriter.ToString();
            }
            Console.WriteLine("Serialized xml is \n {0}", xml);

            Console.WriteLine("Deserializing XML using Streamreader and XMLSerializer");
            using (StringReader reader = new StringReader(xml))
            {
                Person p = (Person)xmlSerializer.Deserialize(reader);
                Console.WriteLine("{0} {1} is {2} years old", p.FirstName, p.LastName, p.Age);
            }
        }

        private void XmlSerializationwithManiputationUsingAttributes()
        {
            Console.WriteLine("Xml Serialization of Complex types using XmlSerializer with Type[] array, StringWriter");
            string xml;
            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VIPOrder) });
            using (StringWriter writer = new StringWriter())
            {
                var orders = CreateOrder();
                serializer.Serialize(writer, orders);
                xml = writer.ToString();
            }

            using (StringReader reader = new StringReader(xml))
            {
                Order o = (Order)serializer.Deserialize(reader);
                Console.WriteLine("Order is deserialized");
            }

        }

        private Order CreateOrder()
        {
            Product prod1 = new Product { ID = 1, Description = "p1", Price = 9 };
            Product prod2 = new Product { ID = 2, Description = "p2", Price = 6 };

            Order order = new VIPOrder
            {
                ID = 4,
                Description = "Order for john dae,use a nice wrap",
                OrderLines = new List<OrderLine>
                {
                    new OrderLine {ID=5,Amount=1,Product=prod1 },
                    new OrderLine {ID=6,Amount=2,Product=prod2 },
                }
            };

            return order;
        }

        private void SimpleBinarySerializationExample()
        {
            Console.WriteLine("Binary Serialization example");
            Console.WriteLine("Non Serialized is valid only on field types not on properties");
            Person2 person2 = new Person2 { ID = 1, Name = "Mayank" };

            Console.WriteLine("Serialing using Binary Formatter into memory stream");
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, person2);
                stream.Position = 0;
                Person2 dp = (Person2)formatter.Deserialize(stream);
                Console.WriteLine("Deserialized Person details are Id:{0} with Name :{1}", dp.ID, dp.Name);
            }

        }

        private void InfluenciingBinarySerializationAndDeserialiation()
        {
            Console.WriteLine("Changing OnSerializing, OnSerialized, OnDeserializing and OnDeserialized methods of Serializable class");
            Person3 person = new Person3 { ID = 2, Name = "Mayank2" };
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, person);
                stream.Position = 0;
                formatter.Deserialize(stream);
            }
        }

        private void ImplementingISerialization()
        {
            Console.WriteLine("Implementing ISerializable Interface with method GetObjectData to secure the public fields value");
            PersonComplex person = new PersonComplex { Id = 3, Name = "Mayank" };
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, person);
                stream.Position = 0;
                PersonComplex personcomplex = (PersonComplex)formatter.Deserialize(stream);
                Console.WriteLine("Deserialized person is with Id:{0} whose name is {1}", personcomplex.Id, personcomplex.Name);
            }
        }

        private void UsingDataContractSerialiation()
        {
            Console.WriteLine("Basic Data Contract Serialization Example");
            Console.WriteLine("The Write Object method of DataContractSerializer can only take Stream object, XmlWriter but cannot take StreamWriter");
            PersonDataContract p1 = new PersonDataContract { Id = 4, Name = "Mayank" };
            using (Stream stream = new FileStream("data.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                {
                    ser.WriteObject(stream, p1);
                }
            }

            using (Stream stream = new FileStream("data.xml", FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
                {
                    PersonDataContract pRead = (PersonDataContract)ser.ReadObject(stream);
                    Console.WriteLine("Read Data is of Person with ID:{0} whose name is {1}", pRead.Id, pRead.Name);
                }
            }
        }

        private void UsingJSONSerializationExample()
        {
            Console.WriteLine("Basic Data Contract JSON Serialization Example");
            PersonDataContract p1 = new PersonDataContract { Id = 5, Name = "Mayank" };
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(PersonDataContract));
                ser.WriteObject(stream, p1);

                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                Console.WriteLine("Result after using StreamReader is {0}",reader.ReadToEnd());

                stream.Position = 0;
                PersonDataContract person = (PersonDataContract)ser.ReadObject(stream);
                Console.WriteLine("Result after desrialization is with ID:{0} and Name: {1}",person.Id,person.Name);
            }
        }

        #region Xml Serialization Support Classes
        [Serializable]
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        [Serializable]
        public class Order
        {
            [XmlAttribute]
            public int ID { get; set; }

            [XmlIgnore]
            public bool IsDirty { get; set; }

            [XmlArray("Lines")]
            [XmlArrayItem("OrderLine")]
            public List<OrderLine> OrderLines { get; set; }
        }

        [Serializable]
        public class VIPOrder : Order
        {
            public string Description { get; set; }
        }

        [Serializable]
        public class OrderLine
        {
            [XmlAttribute]
            public int ID { get; set; }

            [XmlAttribute]
            public int Amount { get; set; }

            [XmlElement("OrderedProduct")]
            public Product Product { get; set; }
        }

        [Serializable]
        public class Product
        {
            [XmlAttribute]
            public int ID { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
        }
        #endregion

        #region Binary Serialization Support classes

        [Serializable]
        public class Person2
        {
            public int ID { get; set; }
            public string Name { get; set; }
            [NonSerialized]
            private bool IsDirty = false;
        }

        [Serializable]
        public class Person3
        {
            public int ID { get; set; }
            public string Name { get; set; }
            [NonSerialized]
            private bool IsDirty = false;

            [OnSerializing]
            internal void OnSerializingMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerializing");
            }

            [OnSerialized]
            internal void OnSerializedMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerialized");
            }

            [OnDeserializing]
            internal void OnDeSerializingMethod(StreamingContext context)
            {
                Console.WriteLine("OnDeSerializing");
            }

            internal void OnDeSerializedMethod(StreamingContext context)
            {
                Console.WriteLine("OnDeSerialized");
            }
        }

        [Serializable]
        public class PersonComplex:ISerializable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private bool isDirty = false;

            public PersonComplex() { }

            protected PersonComplex(SerializationInfo info, StreamingContext context)
            {
                Id = info.GetInt32("Value1");
                Name = info.GetString("Value2");
                isDirty = info.GetBoolean("Value3");
            }

            [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand,SerializationFormatter =true)]
            public void GetObjectData(SerializationInfo info,StreamingContext context)
            {
                info.AddValue("Value1", Id);
                info.AddValue("Value2", Name + "Modified");
                info.AddValue("Value3", isDirty);
            }
        }

        #endregion

        #region DataContract Serialization

        [DataContract]
        public class PersonDataContract
        {
            [DataMember]
            public int Id { get; set; }

            [DataMember]
            public string Name { get; set; }

            public bool isDirty { get; set; }
        }

        #endregion


    }
}