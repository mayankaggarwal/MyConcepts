using CSharpConcepts.Interfaces;
using CSharpConcepts.ThreadingConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    public class ConceptSelectionClass:IConceptSelections
    {
        public void RunConcept(Enum concept)
        {
            IMainMethod mainMethod = null;
            switch((ThreadingConceptsList)concept)
            {
                case ThreadingConceptsList.BasicThread:
                    mainMethod = new Concept1();
                    break;
                case ThreadingConceptsList.IsBackgraoundProperty:
                    mainMethod = new Concept2();
                    break;
                case ThreadingConceptsList.ParameterizedThreads:
                    mainMethod = new Concept3();
                    break;
                case ThreadingConceptsList.AbortingThreads:
                    mainMethod = new Concept4();
                    break;
                case ThreadingConceptsList.VariableSharing:
                    mainMethod = new Concept5();
                    break;
                case ThreadingConceptsList.BasicThreadPool:
                    mainMethod = new Concept6();
                    break;
                case ThreadingConceptsList.BasicTaskExample:
                    mainMethod = new Concept7();
                    break;
                case ThreadingConceptsList.ContinuationTask:
                    mainMethod = new Concept8();
                    break;
                case ThreadingConceptsList.ParentChildTask:
                    mainMethod = new Concept9();
                    break;
                case ThreadingConceptsList.TaskFactoryExample:
                    mainMethod = new Concept10();
                    break;
                case ThreadingConceptsList.WaitAllAndAnyTasks:
                    mainMethod = new Concept11();
                    break;
                case ThreadingConceptsList.ParallelClassExamples:
                    mainMethod = new Concept12();
                    break;
                case ThreadingConceptsList.AsyncBasic:
                    mainMethod = new Concept13();
                    break;
                case ThreadingConceptsList.ScalabilityVsResponsiveness:
                    mainMethod = new Concept14();
                    break;
                case ThreadingConceptsList.PLinqConcepts:
                    mainMethod = new Concept15();
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
        PLinqConcepts
    }
}
