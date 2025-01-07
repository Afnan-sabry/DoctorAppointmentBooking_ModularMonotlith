using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentBooking.Infrastructure.Integration;
using AppointmentBooking.Infrastructure.Repositories;
using AppointmentBooking.Domain.IRepositories;
using Shared.Infrastructure.Extensions;
using AppointmentBooking.Infrastructure.Persistence;
namespace AppointmentBooking.Infrastructure.Extensions
{
    public static class AppointmentBookingInfrastructureExtension
    {

        public static IServiceCollection AddAppointmentBookingInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDatabaseContext<AppointmentBookingDbContext>(config);
            services.AddAppointmentBookingInfrastructureIntegrationExtension(config);
            services.AddScoped<IPatientAppointmentSlotRepository, PatientAppointmentSlotRepository>();

            return services;
        }
    }
}
