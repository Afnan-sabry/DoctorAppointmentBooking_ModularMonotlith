using AppointmentConfirmation.Application.Interfaces;
using AppointmentConfirmation.Infrastructure.Implementaion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentConfirmation.Infrastructure
{
    public static class AddAppointmentConfirmationModuleExtension
    {
        public static async Task<IServiceCollection> AddAppointmentConfirmationModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ISendNotificationService, SendNotificationService>();
            await AppointmentConfirmationModuleStartup.Initialize();
            return services;
        }
    }
}
