using System;

namespace AspNetCoreDemo.Api.Data
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string[] Cast { get; set; }

        public string[] Genres { get; set; }
    }

}
