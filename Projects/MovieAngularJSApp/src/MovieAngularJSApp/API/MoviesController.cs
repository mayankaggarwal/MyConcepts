using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAngularJSApp.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAngularJSApp.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return new List<Movie> {
                new Movie {Id=1, Title="Star Wars", Director="Lucas"},
                new Movie {Id=2, Title="King Kong", Director="Jackson"},
                new Movie {Id=3, Title="Memento", Director="Nolan"}
            };
        }

    }
}
