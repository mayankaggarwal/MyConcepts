using ConsoleApplication1.PeopleService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
      
            PeopleServiceClient client = new PeopleServiceClient();
            string value = client.GetData(45);
            Console.WriteLine(value);
            if(Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
