using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Data.Context;

namespace CodeFirst.Data.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSchoolDbContext(this IServiceCollection services)
        {
            services
                .AddDbContext<SchoolContext>(options =>
                {
                    IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
                    options.UseSqlServer(configuration["ConnectionStrings:School"], x =>
                    {
                        x.MigrationsHistoryTable("EFMigrationsHistory", "School");
                    });
                })
                .AddScoped<SchoolContext>();
            return services;
        }
    }
}
