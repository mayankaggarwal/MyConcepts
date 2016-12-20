using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.OOPSConcepts
{
    public class ConceptSelectionClass:ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((OOPSConceptList)concept)
            {
                case OOPSConceptList.ByRefEamples:
                    conceptExecutionClass = new ByRefEamples();
                    break;
            }
        }

    }

    public enum OOPSConceptList
    {
        ByRefEamples
    }
}
