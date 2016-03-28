using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.DataAccessConcepts
{
    public class ConceptSelectionClass:ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            if(concept.GetType().Equals(typeof(DataAccessConceptsList)))
            {
                switch((DataAccessConceptsList)concept)
                {
                    case DataAccessConceptsList.WorkingWithFilesExamples:
                        conceptExecutionClass = new WorkingWithFilesExamples();
                        break;
                }
            }
        }
    }

    public enum DataAccessConceptsList
    {
        WorkingWithFilesExamples
    }
}
