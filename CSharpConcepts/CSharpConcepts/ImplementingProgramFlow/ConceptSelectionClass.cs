using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ImplementingProgramFlow
{
    public class ConceptSelectionClass : IConceptSelections
    {
        public void RunConcept(Enum concept)
        {
            IMainMethod mainMethod = null;
            switch ((ProgramFlowConceptList)concept)
            {
                case ProgramFlowConceptList.ForeachImplementation:
                    mainMethod = new ForeachImpConcept();
                    break;
            }
            if (mainMethod != null)
            {
                mainMethod.SummaryMethod();
                mainMethod.MainMethod();
            }
            else
                Console.WriteLine("Invalid Concept");
        }
    }

    public enum ProgramFlowConceptList
    {
        ForeachImplementation
    }
}
