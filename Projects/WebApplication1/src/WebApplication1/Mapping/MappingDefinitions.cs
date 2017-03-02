using AutoMapper;
using Orange.IAM.ITE.IDW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public static class MappingDefinitions
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
                cfg.CreateMap<IdentityViewModel, Identity>()
                .ForMember(dest => dest.FirstName, src => src.MapFrom(val => val.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(val => val.LastName))
                .ForMember(dest => dest.StartDate, src => src.MapFrom(val => val.StartDate))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(val => val.EndDate))
                .ForMember(dest => dest.Organization, src => src.MapFrom(val => val.Organization))
                .ForMember(dest => dest.GirDomain, src => src.MapFrom(val => val.GirDomain))
                .ForMember(dest => dest.ManagerCUID, src => src.MapFrom(val => val.ManagerCUID))
                .ForMember(dest => dest.EmployeeType, src => src.MapFrom(val => val.EmployeeType))
                .ForMember(dest => dest.MainEmailAddress, src => src.MapFrom(val => val.MainEmailAddress))
                .ForMember(dest => dest.PreferredFirstName, src => src.MapFrom(val => val.PreferredFirstName))
                .ForMember(dest => dest.MiddleName, src => src.MapFrom(val => val.MiddleName))
                .ForMember(dest => dest.PreferredLastName, src => src.MapFrom(val => val.PreferredLastName))
                .ForMember(dest => dest.LocalID, src => src.MapFrom(val => val.LocalID))
                .ForMember(dest => dest.Description, src => src.MapFrom(val => val.Description))
                .ForMember(dest => dest.PartnerCode, src => src.MapFrom(val => val.PartnerCode))
                .ForMember(dest => dest.SubsidiaryCode, src => src.MapFrom(val => val.SubsidiaryCode))
                .ForMember(dest => dest.HRManager, src => src.MapFrom(val => val.HRManager))
                .ForMember(dest => dest.NotificationMail, src => src.MapFrom(val => val.NotificationMail))
                .ForMember(dest => dest.BirthDate, src => src.MapFrom(val => val.BirthDate))
                .ForMember(dest => dest.ReportingGlobalEnabled, src => src.MapFrom(val => val.ReportingGlobalEnabled))
                .ForMember(dest => dest.title, src => src.MapFrom(val => val.title));

                cfg.CreateMap<Identity, IdentityViewModel>();

            });



        }
    }
}
