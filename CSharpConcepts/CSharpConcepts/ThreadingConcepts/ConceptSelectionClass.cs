using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    public class ConceptSelectionClass: ConceptSelections
    {
        public override void SelectConcept(Enum concept)
        {
            base.SelectConcept(concept);
            switch ((ThreadingConceptsList)concept)
            {
                case ThreadingConceptsList.BasicThread:
                    conceptExecutionClass = new Concept1();
                    break;
                case ThreadingConceptsList.IsBackgraoundProperty:
                    conceptExecutionClass = new Concept2();
                    break;
                case ThreadingConceptsList.ParameterizedThreads:
                    conceptExecutionClass = new Concept3();
                    break;
                case ThreadingConceptsList.AbortingThreads:
                    conceptExecutionClass = new Concept4();
                    break;
                case ThreadingConceptsList.VariableSharing:
                    conceptExecutionClass = new Concept5();
                    break;
                case ThreadingConceptsList.BasicThreadPool:
                    conceptExecutionClass = new Concept6();
                    break;
                case ThreadingConceptsList.BasicTaskExample:
                    conceptExecutionClass = new Concept7();
                    break;
                case ThreadingConceptsList.ContinuationTask:
                    conceptExecutionClass = new Concept8();
                    break;
                case ThreadingConceptsList.ParentChildTask:
                    conceptExecutionClass = new Concept9();
                    break;
                case ThreadingConceptsList.TaskFactoryExample:
                    conceptExecutionClass = new Concept10();
                    break;
                case ThreadingConceptsList.WaitAllAndAnyTasks:
                    conceptExecutionClass = new Concept11();
                    break;
                case ThreadingConceptsList.ParallelClassExamples:
                    conceptExecutionClass = new Concept12();
                    break;
                case ThreadingConceptsList.AsyncBasic:
                    conceptExecutionClass = new Concept13();
                    break;
                case ThreadingConceptsList.ScalabilityVsResponsiveness:
                    conceptExecutionClass = new Concept14();
                    break;
                case ThreadingConceptsList.PLinqConcepts:
                    conceptExecutionClass = new Concept15();
                    break;
                case ThreadingConceptsList.BlockingCollectionExample:
                    conceptExecutionClass = new Concept16();
                    break;
                case ThreadingConceptsList.ConcurrentBagExample:
                    conceptExecutionClass = new Concept17();
                    break;
                case ThreadingConceptsList.ConcurrentStackAndQueueEg:
                    conceptExecutionClass = new Concept19();
                    break;
                case ThreadingConceptsList.ConcurrentDictionaryEg:
                    conceptExecutionClass = new Concept18();
                    break;
                case ThreadingConceptsList.SynchronizationExamples:
                    conceptExecutionClass = new Concept20();
                    break;
                case ThreadingConceptsList.VolatileClassExample:
                    conceptExecutionClass = new Concept21();
                    break;
                case ThreadingConceptsList.ThreadCancellationExamples:
                    conceptExecutionClass = new Concept22();
                    break;
            }

        }
    }

    public enum ThreadingConceptsList
    {
        BasicThread,
        IsBackgraoundProperty,
        ParameterizedThreads,
        AbortingThreads,
        VariableSharing,
        BasicThreadPool,
        BasicTaskExample,
        ContinuationTask,
        ParentChildTask,
        TaskFactoryExample,
        WaitAllAndAnyTasks,
        ParallelClassExamples,
        AsyncBasic,
        ScalabilityVsResponsiveness,
        PLinqConcepts,
        BlockingCollectionExample,
        ConcurrentBagExample,
        ConcurrentStackAndQueueEg,
        ConcurrentDictionaryEg,
        SynchronizationExamples,
        VolatileClassExample,
        ThreadCancellationExamples
    }
}
