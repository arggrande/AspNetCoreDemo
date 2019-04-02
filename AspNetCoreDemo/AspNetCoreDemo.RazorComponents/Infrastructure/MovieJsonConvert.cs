using System.Collections.Generic;
using System.Text.Json;

namespace AspNetCoreDemo.RazorComponents.Infrastructure
{
    public class MovieJsonConvert
    {
        public static IEnumerable<Data.Movie> Deserialize(string moviesJson)
        {
            using var jsonDocument = JsonDocument.Parse(moviesJson);
            var moviesRootElement = jsonDocument.RootElement;
            var movies = new List<Data.Movie>();

            foreach (var movieElement in moviesRootElement.EnumerateArray())
            {
                var movie = new Data.Movie
                {
                    Title = movieElement.GetProperty("title").GetString(),
                    Year = movieElement.GetProperty("year").GetInt32(),
                };

                var castsElement = movieElement.GetProperty("cast");
                var casts = new List<string>();

                foreach (var castElement in castsElement.EnumerateArray())
                {
                    casts.Add(castElement.GetString());
                }
                movie.Cast = casts.ToArray();

                var genresElement = movieElement.GetProperty("genres");
                var generes = new List<string>();

                foreach (var genreElement in genresElement.EnumerateArray())
                {
                    generes.Add(genreElement.GetString());
                }

                movie.Genres = generes.ToArray();

                movies.Add(movie);
            }

            return movies;
        }

        //public static string Serialize(IEnumerable<Movie> movies)
        //{
        //    using var bufferWriter = new ArrayBufferWriter();
        //    var jsonWriter = new Utf8JsonWriter(bufferWriter, state: default);

        //    jsonWriter.WriteStartArray();

        //    foreach(var movie in movies)
        //    {
        //        jsonWriter.WriteStartObject();

        //        jsonWriter.WriteString(nameof(movie.Title).Camelize(), movie.Title);
        //        jsonWriter.WriteNumber(nameof(movie.Year).Camelize(), movie.Year);

        //        jsonWriter.WriteStartArray(nameof(movie.Cast).Camelize());
        //        foreach(var cast in movie.Cast)
        //        {
        //            jsonWriter.WriteStringValue(cast);
        //        }
        //        jsonWriter.WriteEndArray();

        //        jsonWriter.WriteStartArray(nameof(movie.Genres).Camelize());
        //        foreach(var genre in movie.Genres)
        //        {
        //            jsonWriter.WriteStringValue(genre);
        //        }
        //        jsonWriter.WriteEndArray();

        //        jsonWriter.WriteEndObject();
        //    }
        //    jsonWriter.WriteEndArray();

        //    jsonWriter.Flush(isFinalBlock: true);

        //    using var stream = new MemoryStream();
        //    bufferWriter.CopyTo(stream);
        //    var streamReader = new StreamReader(stream);
        //    return streamReader.ReadToEnd();
        //}
    }
}
