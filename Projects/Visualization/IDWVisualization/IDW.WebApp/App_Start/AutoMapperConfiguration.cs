using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDW.WebApp.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => { });
        }
    }
}