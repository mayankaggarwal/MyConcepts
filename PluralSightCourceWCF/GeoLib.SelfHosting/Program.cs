using GeoLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GeoLib.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(GeoManager),
                new Uri("net.tcp://localhost:11011"),
                new Uri("http://localhost:11010"));
            
            

            ServiceDebugBehavior behaviorFaults = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            if(behaviorFaults == null)
            {
                behaviorFaults = new ServiceDebugBehavior();
                behaviorFaults.IncludeExceptionDetailInFaults = true;
                host.Description.Behaviors.Add(behaviorFaults);
            }

            ServiceThrottlingBehavior behaviorThrottling = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
            if(behaviorThrottling==null)
            {
                behaviorThrottling = new ServiceThrottlingBehavior();
                behaviorThrottling.MaxConcurrentSessions = 100;
                behaviorThrottling.MaxConcurrentCalls = 16;
                behaviorThrottling.MaxConcurrentInstances = 116;
                host.Description.Behaviors.Add(behaviorThrottling);
            }

            ServiceMetadataBehavior behaviorServiceMetadata = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if(behaviorServiceMetadata == null)
            {
                behaviorServiceMetadata = new ServiceMetadataBehavior();
                behaviorServiceMetadata.HttpGetEnabled = true;
                host.Description.Behaviors.Add(behaviorServiceMetadata);
            }

            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "MEXTcp");
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "MEXHttp");
            host.Open();


            Se
            Console.WriteLine("Press key to stop the service");
            Console.ReadKey();

            host.Close();
        }
    }
}
