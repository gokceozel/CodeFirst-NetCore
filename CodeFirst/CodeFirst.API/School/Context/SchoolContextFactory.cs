using CodeFirst.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CodeFirst.API.School.Context
{
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configurationRoot.GetValue<string>("ConnectionStrings:School");

            var optionBuilder = new DbContextOptionsBuilder<SchoolContext>();

            optionBuilder.UseSqlServer(connectionString);

            return new SchoolContext(optionBuilder.Options);
           
        }
    }
}
