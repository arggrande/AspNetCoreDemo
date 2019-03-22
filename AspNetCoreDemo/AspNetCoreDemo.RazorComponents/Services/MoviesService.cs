using AspNetCoreDemo.RazorComponents.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreDemo.RazorComponents.Services
{
    public class MoviesService
    {
        public Task<Movie[]> GetMovies()
        {
            return Task.FromResult(new Movie[]
            {
                new Movie {
                    Title = "The Shark",
                    Year = 2019,
                    Cast = new string[] { "Allen Azemia"},
                    Genres = new string[] { "Horror" }
                }
            });
        }
    }
}
