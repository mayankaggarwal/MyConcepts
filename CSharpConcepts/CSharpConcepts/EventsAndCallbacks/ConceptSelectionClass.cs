using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.EventsAndCallbacks
{
    class ConceptSelectionClass : IConceptSelections
    {
        public void RunConcept(Enum concept)
        {
            IMainMethod mainMethod = null;
            switch ((EventsAndCallbacksConceptsList)concept)
            {
                case EventsAndCallbacksConceptsList.BasicDelegateExample:
                    mainMethod = new DelegatesExamples();
                    break;
                case EventsAndCallbacksConceptsList.EventUsingAction:
                    mainMethod = new EventUsingAction();
                    break;
            }

            if(mainMethod!=null)
            {
                mainMethod.SummaryMethod();
                mainMethod.MainMethod();
            }
            else
            {
                Console.WriteLine("Invalid Concept Selected");
            }
        }
    }

    public enum EventsAndCallbacksConceptsList
    {
        BasicDelegateExample,
        EventUsingAction
    }
}
