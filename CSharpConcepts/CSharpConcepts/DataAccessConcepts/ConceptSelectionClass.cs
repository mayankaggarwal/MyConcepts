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
                    case DataAccessConceptsList.WorkingWithStreams:
                        conceptExecutionClass = new WorkingWithStreams();
                        break;
                    case DataAccessConceptsList.WorkingWithADO_DOTNET_Concepts:
                        conceptExecutionClass = new WorkingWithADO_DOTNET_Concepts();
                        break;
                    case DataAccessConceptsList.WorkingWithXMLConcepts:
                        conceptExecutionClass = new WorkingWithXMLExamples();
                        break;
                    case DataAccessConceptsList.LINQExamples:
                        conceptExecutionClass = new LINQExamples();
                        break;
                    case DataAccessConceptsList.SerializationAndDeserializationExamples:
                        conceptExecutionClass = new SerializationAndDeserializationExamples();
                        break;
                }
            }
        }
    }

    public enum DataAccessConceptsList
    {
        WorkingWithFilesExamples,
        WorkingWithStreams,
        WorkingWithADO_DOTNET_Concepts,
        WorkingWithXMLConcepts,
        LINQExamples,
        SerializationAndDeserializationExamples
    }
}
