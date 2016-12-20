#define DEBUG
using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpConcepts.ProgrammingTests
{
    public class CSharp_70_483 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("CSharp Programming test");
        }

        public void MainMethod()
        {
            FormatStringMethod();
            Console.WriteLine("\n --------------------------------------------------------- \n");
            
            RegularExpressionExample();
            Console.WriteLine("\n --------------------------------------------------------- \n");

            DirectiveExample();
            Console.WriteLine("\n --------------------------------------------------------- \n");

            EventsExample();
        }

        private void FormatStringMethod()
        {
            Console.WriteLine("String formating to display result in 3 digits");
            decimal num = 1;
            Console.WriteLine(num.ToString("###"));
            Console.WriteLine(num.ToString("000"));
            Console.WriteLine("{0:###}", num);
        }

        private void RegularExpressionExample()
        {
            Console.WriteLine("Regular expression example");
            Console.WriteLine("Instantiate regular expression at the creation of object");
            Console.WriteLine(" A Regex object is immutable; when you instantiate a Regex object with a regular expression, that object's regular expression cannot be changed");
            Console.WriteLine("regular expression engine must compile a particular pattern before the pattern can be used");
            Console.WriteLine("To eliminate the need to repeatedly compile a single regular expression, the regular expression engine caches the compiled regular expressions used in static method calls.");

            Regex regex = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b", RegexOptions.Compiled);

            string text = "The the quick brown fox  fox jumped over the lazy dog dog.";

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine("{0} matches found in :\n {1}", matches.Count, text);

            foreach(Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                              groups["word"].Value,
                              groups[0].Index,
                              groups[1].Index);
                
            }


        }

        private void DirectiveExample()
        {
            Console.WriteLine("Directive examples");

#if DEBUG
            Console.WriteLine("Inside debug directive");
#else
            Console.WriteLine("Inside elseif of if debug directive");
#endif
        }

        private void EventsExample()
        {
            PrincipleCabin principle = new PrincipleCabin();
            //ClassRoom classRoom = new ClassRoom("1", principle);
            //ClassRoom classRoom1 = new ClassRoom("2", principle);
            //ClassRoom classRoom2 = new ClassRoom("3", principle);
            //ClassRoom classRoom3 = new ClassRoom("4", principle);

            principle.RingBell();

        }
    }

    public class PrincipleCabin
    {
        public event EventHandler<string> RaiseBell;

        public void RingBell()
        {
            //if(RaiseBell!=null)
            //{
                this.RaiseBell(this, "Principle is raising bell");
            //}
        }
    }

    public class ClassRoom
    {
        string roomNumber;
        public ClassRoom(string classname,PrincipleCabin princi)
        {
            this.roomNumber = classname;
            princi.RaiseBell += princi_RaiseBell;
        }

        private void princi_RaiseBell(object sender, string e)
        {
            Console.WriteLine(e + " " + roomNumber);
        }
    }
}
