using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieListApp.Models
{
    public class MovieDBContext:DbContext
    {

        public DbSet<Movie> Movies { get; set; }
    }
}