using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ArticlesExamples
{
    public class ConceptSelectionClass : ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((ArticlesExamplesConceptsList)concept)
            {
                case ArticlesExamplesConceptsList.DeepCloneExample:
                    conceptExecutionClass = new DeepCloneExample();
                    break;
            }
        }
    }

    public enum ArticlesExamplesConceptsList
    {
        DeepCloneExample
    }
}
