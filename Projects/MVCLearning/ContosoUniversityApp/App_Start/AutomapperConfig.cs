using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityApp.App_Start
{
    public static class AutomapperConfig
    {
        public static void SetAutoMapperConfiguration()
        {
            Mapper.CreateMap<ContosoUniversity.Domain.Contoso.Student, ContosoUniversityApp.Models.Student>();
        }
    }
}