using GeoLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(GeoManager));
            host.Open();

            Console.WriteLine("Press key to stop the service");
            Console.ReadKey();

            host.Close();
        }
    }
}
