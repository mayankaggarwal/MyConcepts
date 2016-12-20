using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Program
    {
        static void Main(string[] args)
        {

            Interfaces.ConceptSelections conceptSelection = null;
            //conceptSelection = new ThreadingConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(ThreadingConcepts.ThreadingConceptsList.ParentChildTask);

            //conceptSelection = new ImplementingProgramFlow.ConceptSelectionClass();
            //conceptSelection.RunConcept(ImplementingProgramFlow.ProgramFlowConceptList.ForeachImplementation);

            //conceptSelection = new EventsAndCallbacks.ConceptSelectionClass();
            //conceptSelection.RunConcept(EventsAndCallbacks.EventsAndCallbacksConceptsList.EventInheritanceExample);

            //conceptSelection = new ImplementExceptionHandling.ConceptSelectionClass();
            //conceptSelection.RunConcept(ImplementExceptionHandling.ExceptionsConceptList.ParsingInvalidNumberExceptionEg);

            //conceptSelection = new CSharpTypesConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(CSharpTypesConcepts.CSharpTypeConceptsList.ReflectionExamples);

            //conceptSelection = new SecurityConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(SecurityConcepts.SecurityConcepts.SecureStringExample);

            //conceptSelection = new DebugingConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(DebugingConcepts.DebugApplicationsConcepts.DirectivesExamples);

            //conceptSelection = new DataAccessConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(DataAccessConcepts.DataAccessConceptsList.WorkingWithFilesExamples);

            conceptSelection = new ProgrammingTests.ConceptSelectionClass();
            conceptSelection.RunConcept(ProgrammingTests.ProgrammingTestConceptList.CSharp70_483);

            //conceptSelection = new OOPSConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(OOPSConcepts.OOPSConceptList.ByRefEamples);

        //    int n = Convert.ToInt32(Console.ReadLine());
        //    string B = Console.ReadLine();
        //    int count = 0;
        //    bool found = true;
        //    while (found)
        //    {
        //        found = false;
        //        int i = -1;
        //        i = B.IndexOf("010");
        //        if (i >= 0)
        //        {
        //            count++;
        //            found = true;
        //            if (i > 0 && B[i - 1] == 49)
        //            {
        //                B = ReplaceChar(B, i, "1");
        //            }
        //            else if (i + 3 < B.Length && B[i + 3] == 49)
        //                B = ReplaceChar(B, i + 2, "1");
        //            else
        //                B = ReplaceChar(B, i + 1, "0");
        //        }
        //    }

        //    Console.WriteLine(count);

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit!");
                Console.ReadKey(true);
            }
        }

        //static string ReplaceChar(string input, int index, string c)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (i == index)
        //            builder.Append(c);
        //        else
        //            builder.Append(input[i].ToString());
        //    }

        //    return builder.ToString();
        //}

    }
}
