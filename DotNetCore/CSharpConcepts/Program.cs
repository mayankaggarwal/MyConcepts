using System;
using System.Diagnostics;

namespace CSharpConcepts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            	Console.WriteLine("Hello World!");
		//ProgramFlow programFlow = new ProgramFlow();
		//programFlow.Run();

		//TypesExamples typesExamples = new TypesExamples();
		//typesExamples.Run();

		//UsingTypesExamples usingTypesExamples = new UsingTypesExamples();
		//usingTypesExamples.Run();

		//ClassHierarchiesExamples classHierarchiesExamples = new ClassHierarchiesExamples();
		//classHierarchiesExamples.Run();

		StandardInterfacesExample standardInterfacesExamples = new StandardInterfacesExample();
		standardInterfacesExamples.Run();
		if(Debugger.IsAttached)
		{
			Console.WriteLine("Press Any Key to continue");
			Console.ReadKey();
		}
        }
    }
}
