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
            Interfaces.IConceptSelections concepts = null;
            //concepts = new ThreadingConcepts.ConceptSelectionClass();
            //concepts.RunConcept(ThreadingConcepts.ThreadingConceptsList.ThreadCancellationExamples);
            //concepts = new ImplementingProgramFlow.ConceptSelectionClass();
            //concepts.RunConcept(ImplementingProgramFlow.ProgramFlowConceptList.ForeachImplementation);
            concepts = new EventsAndCallbacks.ConceptSelectionClass();
            concepts.RunConcept(EventsAndCallbacks.EventsAndCallbacksConceptsList.BasicDelegateExample);
            Console.ReadLine();
        }

    }
}
