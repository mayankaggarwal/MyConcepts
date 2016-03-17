using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.CSharpTypesConcepts
{
    public class ConceptSelectionClass : ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((CSharpTypeConceptsList)concept)
            {
                case CSharpTypeConceptsList.StandardInterfacesImplementation:
                    conceptExecutionClass = new StandardInterfacesImplementation();
                    break;
                case CSharpTypeConceptsList.ReflectionExamples:
                    conceptExecutionClass = new ReflectionExamples();
                    break;
                case CSharpTypeConceptsList.ApplyingAttributesExamples:
                    conceptExecutionClass = new ApplyingAttributesExamples();
                    break;
            }
        }
    }

    public enum CSharpTypeConceptsList
    {
        StandardInterfacesImplementation,
        ApplyingAttributesExamples,
        ReflectionExamples
    }
}
