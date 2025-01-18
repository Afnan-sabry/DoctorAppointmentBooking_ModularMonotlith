using DoctorAvailability.DAL.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAvailability.DAL.Extensions;
using DoctorAvailability.DAL.Repositories.AppointmentSlotRepository;
using DoctorAvailability.BLL.Interfaces;
using DoctorAvailability.BLL.Services;
using Shared.Messaging.Messaging;
using Shared.Messaging.Contracts;
using Microsoft.AspNetCore.Builder;
namespace DoctorAvailability.API
{
    public static class DoctorAvailabilityModuleExtension
    {
        public static IServiceCollection AddDoctorAvailabilityModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDoctorAvailabilityInfrastructure(config);
            services.AddScoped<IAppointmentSlotRepository, AppointmentSlotRepository>();
            services.AddScoped<IAppointmentSlotService, AppointmentSlotService>();


            return services;
        }
        public static async Task Initialize(this IApplicationBuilder app)
        {
            try
            {

                // var appointmentSlotService = app.ApplicationServices.GetRequiredService<IAppointmentSlotService>();
                //    var appointmentSlotService = app.ApplicationServices.GetRequiredService<IAppointmentSlotService>();
                using var scope = app.ApplicationServices.CreateScope();
                var appointmentSlotService = scope.ServiceProvider.GetRequiredService<IAppointmentSlotService>();

                RabbitMqSubscriber _subscriber = new();
                await _subscriber.Subscribe<AppointmentSlotBooked>(
                     RabbitMQQueues.AppointmentBooked,
                     message =>
                     {
                         Console.WriteLine($"appointment booking received: {message.AppointmentSlotId}");
                         // Process the message
                         appointmentSlotService.BookAppointmentSlot(message.AppointmentSlotId);
                     });

          

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
