using IDW.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Dependencies;
using IDW.WebApp.Infrastructure.Extensions;

namespace IDW.WebApp.Infrastructure.Extensions
{
    public static class RequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request) 
        { 
            return request.GetService<IMembershipService>(); 
        }
        
        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope(); TService service = (TService)dependencyScope.GetService(typeof(TService));
            return service;
        }
    }
}