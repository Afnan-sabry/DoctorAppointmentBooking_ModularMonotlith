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
using Shared.Messaging.Contracts;
using Shared.Messaging.Messaging;
using Microsoft.AspNetCore.Builder;
using AppointmentBooking.Domain.IRepositories;


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

        public static async Task Initialize(this IApplicationBuilder app)
        {
            try
            {

                // var appointmentSlotService = app.ApplicationServices.GetRequiredService<IAppointmentSlotService>();
                //    var appointmentSlotService = app.ApplicationServices.GetRequiredService<IAppointmentSlotService>();
                using var scope = app.ApplicationServices.CreateScope();
                var appointmentSlotRepo = scope.ServiceProvider.GetRequiredService<IPatientAppointmentSlotRepository>();

                RabbitMqSubscriber _subscriber = new();

                await _subscriber.Subscribe<AppointmentSlotStatusUpdated>(
            RabbitMQQueues.AppointmentStatusUpdated,
            async message =>
            {
                Console.WriteLine($"AppointmentStatusUpdated  received: {message.AppointmentSlotId}");
                // Process the message
                await appointmentSlotRepo.UpdateAppointmentSlotStatus(message.AppointmentSlotId, message.Status);
            });


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
