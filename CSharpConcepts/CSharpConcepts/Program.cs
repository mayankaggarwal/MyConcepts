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
            Interfaces.ConceptSelections conceptSelection = null;
            conceptSelection = new ThreadingConcepts.ConceptSelectionClass();
            conceptSelection.RunConcept(ThreadingConcepts.ThreadingConceptsList.ParentChildTask);

            //conceptSelection = new ImplementingProgramFlow.ConceptSelectionClass();
            //conceptSelection.RunConcept(ImplementingProgramFlow.ProgramFlowConceptList.ForeachImplementation);

            //conceptSelection = new EventsAndCallbacks.ConceptSelectionClass();
            //conceptSelection.RunConcept(EventsAndCallbacks.EventsAndCallbacksConceptsList.EventUsingAction);

            //conceptSelection = new ImplementExceptionHandling.ConceptSelectionClass();
            //conceptSelection.RunConcept(ImplementExceptionHandling.ExceptionsConceptList.ParsingInvalidNumberExceptionEg);

            //conceptSelection = new CSharpTypesConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(CSharpTypesConcepts.CSharpTypeConceptsList.StringManipulationExamples);

            //conceptSelection = new SecurityConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(SecurityConcepts.SecurityConcepts.SecureStringExample);

            //conceptSelection = new DebugingConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(DebugingConcepts.DebugApplicationsConcepts.DirectivesExamples);

            //conceptSelection = new DataAccessConcepts.ConceptSelectionClass();
            //conceptSelection.RunConcept(DataAccessConcepts.DataAccessConceptsList.SerializationAndDeserializationExamples);

            //conceptSelection = new ProgrammingTests.ConceptSelectionClass();
            //conceptSelection.RunConcept(ProgrammingTests.ProgrammingTestConceptList.ProducerConsumerProblem);
            Console.ReadLine();
        }

    }
}
