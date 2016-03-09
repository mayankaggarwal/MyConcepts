using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ImplementExceptionHandling
{
    public class ConceptSelectionClass : IConceptSelections
    {
        public void RunConcept(Enum concept)
        {
            IMainMethod mainMethod = null;
            switch((ExceptionsConceptList)concept)
            {
                case ExceptionsConceptList.ParsingInvalidNumberExceptionEg:
                    mainMethod = new BasicExceptionExample1();
                    break;
            }
            if(mainMethod!=null)
            {
                mainMethod.SummaryMethod();
                mainMethod.MainMethod();
            }
            else
            {
                Console.WriteLine("Invalid Exception Concept selected");
            }
        }
    }

    public enum ExceptionsConceptList
    {
        ParsingInvalidNumberExceptionEg
    }
}
