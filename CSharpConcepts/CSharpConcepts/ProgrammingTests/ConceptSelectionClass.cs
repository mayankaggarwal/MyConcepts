using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ProgrammingTests
{
    class ConceptSelectionClass : ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((ProgrammingTestConceptList)concept)
            {
                case ProgrammingTestConceptList.HankerRankTest1:
                    conceptExecutionClass = new HackerRankTest1();
                    break;
            }
        }
    }

    public enum ProgrammingTestConceptList
    {
        HankerRankTest1
    }
}
