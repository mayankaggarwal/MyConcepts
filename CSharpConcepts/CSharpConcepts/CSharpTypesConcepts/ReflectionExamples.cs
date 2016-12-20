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
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            GetPrimitiveTypeAssembly();
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            InspectingAssemblyExample();
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            IteratingFieldsExample();
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            ExecutingMethodExample();
            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            GettingConstructorInformation();
            GettingTypeAccessModifier();
            GettingMemberInformation();
            GettingMembersSeperately();
        }

        private void GettingConstructorInformation()
        {
            Console.WriteLine("Getting Constructor Information");
            Type type = typeof(System.String);
            ConstructorInfo[] staticConstructorInfo = type.GetConstructors(BindingFlags.Static);
            ConstructorInfo[] instanceConstructorInfo = type.GetConstructors(BindingFlags.Instance);
            ConstructorInfo[] publicConstructorInfo = type.GetConstructors(BindingFlags.Public);
            ConstructorInfo[] nonPublicConstrutorInfo = type.GetConstructors(BindingFlags.NonPublic);

            if(staticConstructorInfo != null && staticConstructorInfo.Count()>0)
            {
                Console.WriteLine("Static constructors present");
                foreach(ConstructorInfo constructorInfo in staticConstructorInfo)
                {
                    PrintMemberInfo(constructorInfo);
                }
            }
            else
            {
                Console.WriteLine("Static constructor not present");
            }

            if (instanceConstructorInfo != null && instanceConstructorInfo.Count() > 0)
            {
                Console.WriteLine("Instance constructors present");
                foreach (ConstructorInfo constructorInfo in instanceConstructorInfo)
                {
                    PrintMemberInfo(constructorInfo);
                }
            }
            else
            {
                Console.WriteLine("Instance constructor not present");
            }

            if (publicConstructorInfo != null && publicConstructorInfo.Count() > 0)
            {
                Console.WriteLine("Public constructors present");
                foreach (ConstructorInfo constructorInfo in publicConstructorInfo)
                {
                    PrintMemberInfo(constructorInfo);
                }
            }
            else
            {
                Console.WriteLine("Public constructor not present");
            }

            if (nonPublicConstrutorInfo != null && nonPublicConstrutorInfo.Count() > 0)
            {
                Console.WriteLine("Non public constructors present");
                foreach (ConstructorInfo constructorInfo in nonPublicConstrutorInfo)
                {
                    PrintMemberInfo(constructorInfo);
                }
            }
            else
            {
                Console.WriteLine("Non Public constructor not present");
            }
        }

        private void GettingTypeAccessModifier()
        {
            Console.WriteLine("Getting Type access modifier");
            Type type = Type.GetType("System.IO.File");
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo memberInfo in members)
                PrintMemberInfo(memberInfo);
            if (type.IsPublic)
                Console.WriteLine("Type is public");

        }

        private void GettingMemberInformation()
        {
            Console.WriteLine("Getting member information and execute it");
            Type type = Type.GetType("System.Reflection.FieldInfo");
            MemberInfo[] memberInformation = type.GetMembers();
           
        }

        private void GettingMembersSeperately()
        {
            throw new NotImplementedException();
        }

        private void PrintMemberInfo(MemberInfo memberInfo)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Constructor:
                    ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
                    if (constructorInfo != null)
                    {
                        Console.WriteLine("Member Name:{0},\t Declaring type:{1},\t Member Type:{2},\t Module:{3},\t Member:{4}"
                        , constructorInfo.Name, constructorInfo.DeclaringType.Name, constructorInfo.MemberType, constructorInfo.Module
                        , constructorInfo);
                        foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
                        {
                            PrintParameterInfo(parameterInfo);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to typecase to constructor info");
                    }
                    break;
                default:
                    Console.WriteLine("Member Name:{0},\t Declaring type:{1},\t Member Type:{2},\t Module:{3},\t Member:{4}"
                        , memberInfo.Name, memberInfo.DeclaringType.Name, memberInfo.MemberType, memberInfo.Module, memberInfo);
                    break;
            }
        }

        private void PrintParameterInfo(ParameterInfo parameterInfo)
        {
            Console.WriteLine("Paramter:{0},\t Name:{1},\t Default value:{2}", parameterInfo, parameterInfo.Name, parameterInfo.ParameterType.Name, parameterInfo.DefaultValue);
        }

        private void SimpleReflectionExample()
        {
            Console.WriteLine("Simple Reflection Example");
            int i = 42;
            System.Type type = i.GetType();
            Console.WriteLine("The type of variable is :{0}", type.Name);
        }


        private void GetPrimitiveTypeAssembly()
        {
            Console.WriteLine("Get assembly of int");
            System.Reflection.Assembly info = typeof(Int32).Assembly;
            Console.WriteLine(info);
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