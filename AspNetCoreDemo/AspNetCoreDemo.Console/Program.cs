using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var filePath = @"D:\Projects\VS2019LaunchParty\AspNetCoreDemo\Dataset\movies.json";
            var moviesDataset = await File.ReadAllTextAsync(filePath);
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var movies = MovieJsonConvert.Deserialize(moviesDataset);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine("Utf8 Elapsed time: {0}", elapsedMs);

            watch = System.Diagnostics.Stopwatch.StartNew();
            movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(moviesDataset);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine("Utf16 Elapsed time: {0}", elapsedMs);

            System.Console.WriteLine("Writing Utf8 Json");
            watch = System.Diagnostics.Stopwatch.StartNew();
            var serializedMovies = MovieJsonConvert.Serialize(movies);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine("Utf8 Elapsed time: {0}", elapsedMs);

            System.Console.WriteLine("Writing Normal Json");
            watch = System.Diagnostics.Stopwatch.StartNew();
            serializedMovies = JsonConvert.SerializeObject(movies);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            System.Console.WriteLine("Utf16 Elapsed time: {0}", elapsedMs);

            System.Console.WriteLine("Movies loaded");
            System.Console.ReadLine();
        }
    }
}
