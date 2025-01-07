using AppointmentBooking.Application.ExternalServiceInterfaces;
using AppointmentBooking.Infrastructure.Integration.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Infrastructure.Integration
{
    public static class AppointmentBookingInfrastructureIntegrationExtension
    {
        public static IServiceCollection AddAppointmentBookingInfrastructureIntegrationExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBookingAppointmentSlotService, BookingAppointmentSlotService>();

            return services;
        }

    }
}
