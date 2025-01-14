using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
 
        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
        {
            var connectionString = config.GetConnectionString("Default");
            services.AddMSSQL<T>(connectionString);
            return services;
        }

        private static IServiceCollection AddMSSQL<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
           // services.AddDbContext<T>(m => m.UseSqlServer(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
            services.AddDbContext<T>(m => m.UseSqlServer(connectionString));

            return services;
        }
    }

}
