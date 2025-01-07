using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentBooking.Infrastructure.Extensions;

namespace AppointmentBookingModule.API
{
    public static class AppointmentBookingModuleExtension
    {
        public static IServiceCollection AddAppointmentBookingModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddAppointmentBookingInfrastructure(config);
            return services;
        }
    }
}
