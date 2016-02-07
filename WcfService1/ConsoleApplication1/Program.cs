using ConsoleApplication1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();
            CompositeType composite = new CompositeType();
            ClassWithoutDC classwithoutDC = new ClassWithoutDC();
           
        }
    }
}
