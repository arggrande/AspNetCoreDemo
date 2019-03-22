using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNetCoreDemo.Data
{
    public class MoviesContextDbFactory : IDesignTimeDbContextFactory<MoviesContext>
    {
        public MoviesContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<MoviesContext>();
            var connectionString = configuration.GetConnectionString("AspNetCoreDemo");

            builder.UseSqlServer(connectionString);

            return new MoviesContext(builder.Options);
        }
    }

}
