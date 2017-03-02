using IDW.Data.Infrastructure;
using IDW.Data.Repositories;
using IDW.Entities.Utility;
using IDW.WebApp.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IDW.WebApp.Controllers
{
    [Authorize(Roles="Admin")]
    [RoutePrefix("api/cognospackage")]
    public class CognosPackageController : ApiControllerBase
    {
        public CognosPackageController(IEntityBaseRepository<Error> _errorRepository, IUnitOfWork _unitOfWork)
            : base(_errorRepository, _unitOfWork)
        {

        }

        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage Upload(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //if (!ModelState.IsValid) { 
                //    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); }
                //else
                //{
                //    var movieDb = _moviesRepository.GetSingle(movie.ID);
                //    if (movieDb == null) 
                //        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
                //    else
                //    {
                //        movieDb.UpdateMovie(movie); movie.Image = movieDb.Image; _moviesRepository.Edit(movieDb);
                //        _unitOfWork.Commit(); 
                //        response = request.CreateResponse<MovieViewModel>(HttpStatusCode.OK, movie);
                //    }
                //}
                response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [MimeMultipart]
        [Route("packages/upload")]
        public HttpResponseMessage Post(HttpRequestMessage request)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var uploadPath = HttpContext.Current.Server.MapPath("~/Content/images/movies");
                var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);
                // Read the MIME multipart asynchronously
                Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);
                string _localFileName = multipartFormDataStreamProvider.FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

                // Create response 
                FileUploadResult fileUploadResult = new FileUploadResult
                {
                    LocalFilePath = _localFileName,
                    FileName = Path.GetFileName(_localFileName),
                    FileLength = new FileInfo(_localFileName).Length
                };
                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }
    }
}
