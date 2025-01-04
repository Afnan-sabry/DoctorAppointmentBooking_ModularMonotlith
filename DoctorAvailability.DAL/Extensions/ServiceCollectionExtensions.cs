using DoctorAvailability.DAL.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Extensions;
using Shared.Infrastructure.Persistence;

namespace DoctorAvailability.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDoctorAvailabilityInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<DoctorAvailabilityDBContext>(config);
            return services;
        }
    }
}
