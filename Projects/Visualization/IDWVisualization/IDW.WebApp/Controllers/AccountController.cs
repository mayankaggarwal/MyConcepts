using IDW.Data.Infrastructure;
using IDW.Data.Repositories;
using IDW.Entities.Utility;
using IDW.Services.Abstract;
using IDW.Services.Utilities;
using IDW.WebApp.Infrastructure.Core;
using IDW.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IDW.WebApp.Controllers
{
    [Authorize(Roles="Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorRepository,IUnitOfWork _unitOfWork)
            :base(_errorRepository,_unitOfWork)
        {
            _membershipService = membershipService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request,LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);
                    if(_userContext.User!=null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request,RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if(ModelState.IsValid)
                {
                    Entities.Membership.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[]{1});
                    if(_user!=null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                return response;
            });
        }
    }
}
