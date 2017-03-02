using AutoMapper;
using Orange.IAM.ITE.GIR.MapperIdentities;
using Orange.IAM.ITE.IDW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using TigerServiceReference;

namespace Orange.IAM.ITE.GIR
{
    public class TigerService
    {
        IdentityServiceClient client;
        ChannelFactory<TigerServiceReference.IdentityService> factory = null;
        IdentityService serviceProxy = null;
        Binding binding = null;
        public TigerService()
        {
            AutoMapperConfig.SetAutoMapperConfiguration();
            binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            factory = new ChannelFactory<IdentityService>(binding, new EndpointAddress("http://10.195.216.122:9004/TGRWS-ws/IdentityService?wsdl"));
            serviceProxy = factory.CreateChannel();
            //client = new IdentityServiceClient();
        }

        public long CreateIdentity(Identity identity)
        {
            
            BWSIdentity dto = new BWSIdentity();
            try
            {
                dto = Mapper.Map<Identity, BWSIdentity>(identity);
            }catch(Exception exp)
            {
                throw;
            }
            //Task<createResponse> result = client.createAsync(dto);
            var result = serviceProxy.createAsync(new create { identity = dto });
            Task.WaitAll(result);
            var result1 = result.Result;
            return result1.@return.requestId;

        }

        private BWSIdentity MapCustom(Identity identity)
        {
            BWSIdentity bws = new BWSIdentity();
            bws.firstName = new deletableString { Value = identity.FirstName };
            bws.lastName = new deletableString { Value = identity.LastName };
            bws.startDate = new deletableDateTime { Value = identity.StartDate.HasValue?identity.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ss:00Z"):null };
            bws.organization = new deletableString { Value = identity.Organization };
            bws.girDomain = new deletableString { Value = identity.GirDomain };
            bws.managerCUID = new deletableString { Value = identity.ManagerCUID };
            bws.employeeType = new deletableString { Value = identity.EmployeeType };
            bws.birthDate = new deletableDateTime { Value = identity.StartDate.HasValue ? identity.BirthDate.Value.ToString("yyyy-MM-ddTHH:mm:ss:00Z"):null };
            bws.reportingGlobalEnabled = identity.ReportingGlobalEnabled;

            return bws;
        }
    }
}
