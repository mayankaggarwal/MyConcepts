using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadingConcepts.ConceptSelectionClass conceptSelection = new ThreadingConcepts.ConceptSelectionClass();
            conceptSelection.RunConcept(ThreadingConcepts.ThreadingConceptsList.WaitAllAndAnyTasks);
            Console.ReadLine();
        }
    }
}
