using AspNetCoreDemo.RazorComponents.Data;
using AspNetCoreDemo.RazorComponents.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreDemo.RazorComponents.Services
{
    public class MoviesService
    {
        public Task<Movie[]> GetMoviesAsync()
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

        public async Task<IEnumerable<Data.Movie>> GetMovieBlobUtf8Async()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:5001/api/movies/utf8");
            var moviesStr = await response.Content.ReadAsStringAsync();
            var result = MovieJsonConvert.Deserialize(moviesStr);
            return result;
        }

        public async Task<IEnumerable<Data.Movie>> GetMovieBlobUtf16Async()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:5001/api/movies/utf16");
            var moviesStr = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Data.Movie>>(moviesStr);
            return result;
        }
    }
}
