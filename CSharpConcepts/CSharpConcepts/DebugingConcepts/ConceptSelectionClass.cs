using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.DebugingConcepts
{
    public class ConceptSelectionClass:ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            if (concept.GetType().Equals(typeof(DebugApplicationsConcepts)))
            {
                switch ((DebugApplicationsConcepts)concept)
                {
                    case DebugApplicationsConcepts.ReleaseAndDebugMode:
                        conceptExecutionClass = new ReleaseAndDebugDiffExecution();
                        break;
                    case DebugApplicationsConcepts.DirectivesExamples:
                        conceptExecutionClass = new DirectivesUsageExamples();
                        break;
                }
            }
        }
    }

    public enum DebugApplicationsConcepts
    {
        ReleaseAndDebugMode,
        DirectivesExamples
    }
}
