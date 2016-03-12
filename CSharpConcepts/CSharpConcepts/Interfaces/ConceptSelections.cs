using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Interfaces
{
    public abstract class ConceptSelections
    {
        protected IMainMethod conceptExecutionClass;

        public virtual void SelectConcept(Enum concept)
        {
            conceptExecutionClass = null;
        }

        public void RunConcept(Enum concept)
        {
            SelectConcept(concept);
            if(conceptExecutionClass!=null)
            {
                conceptExecutionClass.SummaryMethod();
                conceptExecutionClass.MainMethod();
            }
            else
            {
                Console.WriteLine("Invalid concept");
            }
        }
    }
}
