using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.EventsAndCallbacks
{
    class ConceptSelectionClass : ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((EventsAndCallbacksConceptsList)concept)
            {
                case EventsAndCallbacksConceptsList.BasicDelegateExample:
                    conceptExecutionClass = new DelegatesExamples();
                    break;
                case EventsAndCallbacksConceptsList.EventUsingAction:
                    conceptExecutionClass = new EventUsingAction();
                    break;
                case EventsAndCallbacksConceptsList.EventInheritanceExample:
                    conceptExecutionClass = new EventInheritanceExample();
                    break;
            }
        }
    }

    public enum EventsAndCallbacksConceptsList
    {
        BasicDelegateExample,
        EventUsingAction,
        EventInheritanceExample
    }
}
