using System;
using CSharpConcepts.Interfaces;
using System.Reflection;
using SampleAssembly1;
using System.Linq;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class ReflectionExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Reflection Examples");
            Console.WriteLine("A .Net application contains code, data and also metadata.");
            Console.Write("Metadata Information like attributes. Other metadata contain information about");
            Console.WriteLine("types, code, assembly and all other elements stored in application");
            Console.WriteLine("Reflection is the process of retriveing this metadata information at runtime");
        }

        public void MainMethod()
        {
            //Console.WriteLine("Not implemented");
            SimpleReflectionExample();
            InspectingAssemblyExample();
            IteratingFieldsExample();
            ExecutingMethodExample();
        }

        private void SimpleReflectionExample()
        {
            Console.WriteLine("Simple Reflection Example");
            int i = 42;
            System.Type type = i.GetType();
            Console.WriteLine("The type of variable is :{0}", type.Name);
        }

        private void InspectingAssemblyExample()
        {
            Console.WriteLine("Inspecting assemply using reflection to check if it contains implementation of an interface");
            Assembly pluginAssembly = Assembly.Load("SampleAssembly2");
            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;

            foreach(Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
                Console.WriteLine(plugin.Name);
                Console.WriteLine(plugin.Description);
            }
        }

        private void IteratingFieldsExample()
        {
            Console.WriteLine("Iterating over fields of type using reflection");
            Employee emp = new Employee(607147, "Mayank", "Aggarwal", 0, "OBS", ".Net");
            DumpObject(emp);
        }

        private void DumpObject(Object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach(FieldInfo info in fields)
            {
                Console.Write(info.Name + " :" + info.GetValue(obj));
                if (info.FieldType == typeof(int))
                    Console.Write(" Int type field");

                Console.WriteLine();
            }
        }

        private void ExecutingMethodExample()
        {
            Console.WriteLine("Executing Method using Reflection");
            int i = 42;
            MethodInfo compareMethod = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            int result = (int)compareMethod.Invoke(i, new object[] { 42 });
            Console.WriteLine(result);
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            private int Salary;
            private string Organization;
            public string Skills { private set; get; }

            public Employee(int ID,string Name,string LastName,int Salary,string Organization,string skills)
            {
                this.ID = ID;
                this.Name = Name;
                this.LastName = LastName;
                this.Salary = Salary;
                this.Organization = Organization;
                this.Skills = skills;
            }
        }
    }
}