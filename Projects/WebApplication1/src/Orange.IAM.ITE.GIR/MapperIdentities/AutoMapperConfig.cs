using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Orange.IAM.ITE.IDW.Entities;
using TigerServiceReference;
using GIRServiceReference;

namespace Orange.IAM.ITE.GIR.MapperIdentities
{
    public static class AutoMapperConfig
    {
        private static bool autoMapperConfigured = false;
        private static object autoMapperLock = new object();

        public static void SetAutoMapperConfiguration()
        {
            if (!autoMapperConfigured)
            {
                lock (autoMapperLock)
                {
                    if (!autoMapperConfigured)
                    {
                        autoMapperConfigured = true;
                        SetAutoMapperConfigurationPrivate();
                    }
                }
            }
        }

        private static void SetAutoMapperConfigurationPrivate()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<String, deletableString>()
                .ForMember(dest => dest.Value, src => src.MapFrom(val => val));

                cfg.CreateMap<int,deletableInt>()
                .ForMember(dest => dest.Value, src => src.MapFrom(val => val));

                cfg.CreateMap<Identity, BWSIdentity>()
                .ForMember(dest => dest.firstName, src => src.MapFrom(val => new deletableString { Value = val.FirstName }))
                .ForMember(dest => dest.lastName, src => src.MapFrom(val => new deletableString { Value = val.LastName }))
                .ForMember(dest => dest.startDate, src => src.MapFrom(val => new deletableDateTime { Value = val.StartDate.HasValue?val.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ss:00Z"):null }))
                .ForMember(dest => dest.organization, src => src.MapFrom(val => new deletableString { Value = val.Organization }))
                .ForMember(dest => dest.girDomain, src => src.MapFrom(val => new deletableString { Value = val.GirDomain }))
                .ForMember(dest => dest.managerCUID, src => src.MapFrom(val => new deletableString { Value = val.ManagerCUID }))
                .ForMember(dest => dest.employeeType, src => src.MapFrom(val => new deletableString { Value = val.EmployeeType }))
                .ForMember(dest => dest.birthDate, src => src.MapFrom(val => new deletableDateTime { Value = val.BirthDate.HasValue?val.BirthDate.Value.ToString("yyyy-MM-ddTHH:mm:ss:00Z"):null }))
                .ForMember(dest => dest.reportingGlobalEnabled, src => src.MapFrom(val => val.ReportingGlobalEnabled))
                .ForMember(dest => dest.title, src => src.MapFrom(val => new BWSTitle() { Value = TigerServiceReference.BWSTitleValues.MR }));


                cfg.CreateMap<Item, EmployeeCategory>()
                .ForMember(dest => dest.ID, src => src.MapFrom(val => val.Id))
                .ForMember(dest => dest.Category, src => src.MapFrom(val => val.Value));

                cfg.CreateMap<Item, EmployeeDomain>()
                .ForMember(dest => dest.ID, src => src.MapFrom(val => val.Id))
                .ForMember(dest => dest.Domain, src => src.MapFrom(val => val.Value));

                cfg.CreateMap<Item, GroupSubsidiary>()
                .ForMember(dest => dest.ID, src => src.MapFrom(val => val.Id))
                .ForMember(dest => dest.Subsidiary, src => src.MapFrom(val => val.Value));

                cfg.CreateMap<Item, Partner>()
                .ForMember(dest => dest.ID, src => src.MapFrom(val => val.Id))
                .ForMember(dest => dest.PartnerName, src => src.MapFrom(val => val.Value));

                cfg.CreateMap<EmployeeCategory,Item >()
                .ForMember(dest => dest.Id, src => src.MapFrom(val => val.ID))
                .ForMember(dest => dest.Value, src => src.MapFrom(val => val.Category));

                cfg.CreateMap<EmployeeDomain, Item>()
                .ForMember(dest => dest.Id, src => src.MapFrom(val => val.ID))
                .ForMember(dest => dest.Value, src => src.MapFrom(val => val.Domain));

                cfg.CreateMap<GroupSubsidiary, Item>()
                .ForMember(dest => dest.Id, src => src.MapFrom(val => val.ID))
                .ForMember(dest => dest.Value, src => src.MapFrom(val => val.Subsidiary));

                cfg.CreateMap<Partner, Item>()
                .ForMember(dest => dest.Id, src => src.MapFrom(val => val.ID))
                .ForMember(dest => dest.Value, src => src.MapFrom(val => val.PartnerName));
            });

           

        }
    }
}
