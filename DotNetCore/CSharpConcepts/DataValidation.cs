#define directives
#define directives3
#undef DEBUG
using System;
using System.Diagnostics;

namespace CSharpConcepts
{
	public class DataValidations
	{
		public void Run()
		{
			Console.WriteLine("Inside Data validations");
			//FirstDirectiveExample();
			PredefinedDirectivesExample();
		}

		public void FirstDirectiveExample()
		{
			#if directives
				Console.WriteLine("Preprocessor directive present");
			#else
				Console.WriteLine("Preprocessor directive not present");
			#endif

			#if directives && directives2
				Console.WriteLine("Both directives present");
			#else
				Console.WriteLine("Both directives not present");
			#endif

			#if directives && directives3
				Console.WriteLine("Both directives present");
			#elif directives && !directives3
				Console.WriteLine("directives present");
			#endif

			#if directives
				#warning Using directives for warning
			#endif
				
		}

		public void PredefinedDirectivesExample()
		{
			Console.WriteLine("Inside predefined directives example");
			Debug.Assert(false);

			
		}
	}
}
