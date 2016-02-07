using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadingConcepts.IMainMethod concepts = new ThreadingConcepts.Concept4();
            concepts.MainMethod();
            Console.ReadLine();
        }
    }
}
