using AutoMapper;
using GIRServiceReference;
using Orange.IAM.ITE.GIR.MapperIdentities;
using Orange.IAM.ITE.IDW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Orange.IAM.ITE.GIR
{
    public class GIRService
    {
        ChannelFactory<GIR_IOSWW> factory = null;
        GIR_IOSWW serviceProxy = null;
        Binding binding = null;
        string certData;
        public GIRService()
        {
            AutoMapperConfig.SetAutoMapperConfiguration();
            binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            factory = new ChannelFactory<GIR_IOSWW>(binding, new EndpointAddress("http://10.195.176.137:8091/GIR_IOSWW.svc?wsdl"));
            serviceProxy = factory.CreateChannel();
            certData = "MIIB3DCCAYagAwIBAgIQELXEvzZ7oZ1Nf1V75TzPRTANBgkqhkiG9w0BAQQFADAWMRQwEgYDVQQDEwtSb290IEFnZW5jeTAeFw0xMTAxMjcxMzEzMTBaFw0xMzAxMjcxMzEzMDlaMDcxNTAzBgNVBAMeLABNAE8ARQAgAEcASQBSACAAVABFAFMAVABfAEMAaAByAGkAcwBtAGUAbgB0MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDEQ4MO1XbzZ3yrw6voHeK2mhgJLXyMQDHl41GrvsTqstaGt/jgG1aPAdp9FnC0kqwqec8GR0G4DrnWh/c0HDZLgccfNHF/vnMfrzEEX1mb61ANtZHbLrIuWAOuLZpHoKcyz9Ns951V0TAX0J1pohLXtj8HuI/GpY7PmqQslX+WFwIDAQABo0swSTBHBgNVHQEEQDA+gBAS5AktBh0dTwCNYSHcFmRjoRgwFjEUMBIGA1UEAxMLUm9vdCBBZ2VuY3mCEAY3bACqAGSKEc+41KpcNfQwDQYJKoZIhvcNAQEEBQADQQAr8FEx/GxdGvDYdNDtbt8q30lKjeIGjzwbDyhJcXd6cUiZmCQCB9y0ULUdy276folvgtpVZYCxsOd9cw0rJ1GN";
        }

        public List<EmployeeCategory> GetCategories()
        {
            List<EmployeeCategory> employeeCategory = new List<EmployeeCategory>();
            var result = serviceProxy.GetCategoriesAsync(ConvertCertData(certData));
            try
            {
                employeeCategory = Mapper.Map<List<Item>, List<EmployeeCategory>>(result.Result.ToList());
            }
            catch (Exception exp)
            {
                throw;
            }

            return employeeCategory;
        }

        public List<String> GetCategoriesList()
        {
            List<String> employeeCategory = new List<String>();
            var result = serviceProxy.GetAllCategoryValuesAsync(ConvertCertData(certData));
            try
            {
                employeeCategory = result.Result.ToList();
            }
            catch (Exception exp)
            {
                throw;
            }

            return employeeCategory;
        }

        public List<EmployeeDomain> GetDomains()
        {
            List<EmployeeDomain> employeeDomain = new List<EmployeeDomain>();
            var result = serviceProxy.GetDomainsAsync(ConvertCertData(certData));
            try
            {
                employeeDomain = Mapper.Map<List<Item>, List<EmployeeDomain>>(result.Result.ToList());
            }
            catch (Exception exp)
            {
                throw;
            }

            return employeeDomain;
        }

        public List<GroupSubsidiary> GetGroupSubsidiary()
        {
            List<GroupSubsidiary> groupSubsidiary = new List<GroupSubsidiary>();
            var result = serviceProxy.GetCategoriesAsync(ConvertCertData(certData));
            try
            {
                groupSubsidiary = Mapper.Map<List<Item>, List<GroupSubsidiary>>(result.Result.ToList());
            }
            catch (Exception exp)
            {
                throw;
            }

            return groupSubsidiary;
        }

        public List<Partner> GetPartner()
        {
            List<Partner> partner = new List<Partner>();
            var result = serviceProxy.GetCategoriesAsync(ConvertCertData(certData));
            try
            {
                partner = Mapper.Map<List<Item>, List<Partner>>(result.Result.ToList());
            }
            catch (Exception exp)
            {
                throw;
            }

            return partner;
        }

        private static byte[] ConvertCertData(string certData)
        {
            var byteArray = Convert.FromBase64String(certData);
            return byteArray;
        }
    }
}
