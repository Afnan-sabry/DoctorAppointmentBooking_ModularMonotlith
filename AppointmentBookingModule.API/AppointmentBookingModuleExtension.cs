using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentBooking.Infrastructure.Extensions;
using System.Reflection;
using AppointmentBooking.Application.Extensions;
using AppointmentBooking.Application.Commands.BookAppointment;
using MediatR;


namespace AppointmentBookingModule.API
{
    public static class AppointmentBookingModuleExtension
    {
        public static IServiceCollection AddAppointmentBookingModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddAppointmentBookingApplication(config);
            services.AddAppointmentBookingInfrastructure(config);
            services.AddMediatR(configuration =>
            {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
