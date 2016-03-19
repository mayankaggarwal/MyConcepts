using System;
using CSharpConcepts.Interfaces;
using System.Diagnostics;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class ApplyingAttributesExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("ApplyingAttributes");
            Console.WriteLine("Attributes can be added to all kinds of types: assemblies, types, methods, parameters and properties");
            Console.WriteLine("Custom attributes can store all kinds of information that we want");

        }

        public void MainMethod()
        {
            SerialiableAttributeExample();
            ConditionalAttributeExample();
            CustomAttributeExample();
        }

        private void SerialiableAttributeExample()
        {
            Console.WriteLine("Serializable attribute example");
            if(Attribute.IsDefined(typeof(Person),typeof(SerializableAttribute)))
            {
                Console.WriteLine("Serializable attribute found for class Person");
            }
            else
            {
                Console.WriteLine("Serializable attribute not defined for type Person");
            }
        }

        private void ConditionalAttributeExample()
        {
            Console.WriteLine("Conditional Attribute Example");
            ConditionalAttribute conditionalAttribute = (ConditionalAttribute)Attribute.GetCustomAttribute(typeof(ConditionalClass), typeof(ConditionalAttribute));
            if (null != conditionalAttribute)
            {
                string condition = conditionalAttribute.ConditionString;
                Console.WriteLine(condition);
            }
            else
                Console.WriteLine("No condition attribute found");

            Console.WriteLine("Conditional attributes can be applied to methods or attribute class");
        }

        private void CustomAttributeExample()
        {
            Console.WriteLine("CustomAttribute example");
            if(Attribute.IsDefined(typeof(CustomAttributeClass),typeof(CompleteCustomAttribute)))
            {
                Console.WriteLine("Custom attribute applied");
            }
            else
            {
                Console.WriteLine("Custom attribute not applied");
            }

            CompleteCustomAttribute customAttribute = (CompleteCustomAttribute)Attribute.GetCustomAttribute(typeof(CustomAttributeClass), typeof(CompleteCustomAttribute));
            if(null != customAttribute)
            {
                string description = customAttribute.Description;
                Console.WriteLine("Description of custom attribute :" + description);
            }

        }

        [Serializable]
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [Conditional("Conditionclass")]
        public class ConditionalClass : Attribute
        {
            [Conditional("CONDITION1"),Conditional("CONDITION2")]
            static void Method1() { }
        }


        [CompleteCustom("CustomAttribute1")]
        public class CustomAttributeClass
        {
            public string ID { get; set; }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
        public class CompleteCustomAttribute:Attribute
        {
            public CompleteCustomAttribute(string description)
            {
                this.Description = description;
            }

            public string Description { get; private set; }
        }
    }
}