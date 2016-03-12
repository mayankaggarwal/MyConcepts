using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ImplementingProgramFlow
{
    public class ConceptSelectionClass : ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((ProgramFlowConceptList)concept)
            {
                case ProgramFlowConceptList.ForeachImplementation:
                    conceptExecutionClass = new ForeachImpConcept();
                    break;
            }
        }
    }

    public enum ProgramFlowConceptList
    {
        ForeachImplementation
    }
}
