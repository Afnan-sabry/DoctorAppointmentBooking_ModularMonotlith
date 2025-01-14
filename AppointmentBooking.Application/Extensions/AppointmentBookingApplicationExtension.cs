using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Shared.Messaging;

namespace AppointmentBooking.Application.Extensions
{
    public static class AppointmentBookingApplicationExtension
    {
        public static IServiceCollection AddAppointmentBookingApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddMessagingExtension(config);

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
