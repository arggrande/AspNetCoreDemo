using AspNetCoreDemo.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private const string FilePath = @".\Dataset\movies.json";

        private readonly IHostingEnvironment _hostingEnvironment;

        public MoviesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("utf8")]
        [Produces(typeof(IEnumerable<Data.Movie>))]
        public async Task<IActionResult> GetUtf8()
        {
            var moviesStr = await System.IO.File.ReadAllTextAsync(FilePath);
            var movies = MovieJsonConvert.Deserialize(moviesStr);
            return Ok(movies);
        }

        [HttpGet("utf16")]
        [Produces(typeof(IEnumerable<Data.Movie>))]
        public async Task<IActionResult> GetUtf16()
        {
            var moviesStr = await System.IO.File.ReadAllTextAsync(FilePath);
            var movies = JsonConvert.DeserializeObject<IEnumerable<Data.Movie>>(moviesStr);
            return Ok(movies);
        }
    }
}
