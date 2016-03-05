using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ProgrammingTests
{
    class ConceptSelectionClass : IConceptSelections
    {
        public void RunConcept(Enum concept)
        {
            IMainMethod mainMethod = null;
            switch ((ProgrammingTestConceptList)concept)
            {
                case ProgrammingTestConceptList.HankerRankTest1:
                    mainMethod = new HackerRankTest1();
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

    public enum ProgrammingTestConceptList
    {
        HankerRankTest1
    }
}
