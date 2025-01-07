using AppointmentConfirmation.Application.Dtos;
using AppointmentConfirmation.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentConfirmation.Infrastructure.Implementaion
{
    internal class SendNotificationService(ILogger<SendNotificationService>logger) : ISendNotificationService
    {
        public async Task<Response> SendBookingAppointmentSlotNotification(SendBookingAppointmentSlotNotification model)
        {
            var msg = JsonConvert.SerializeObject(model);
            logger.LogInformation($"Appointment Booking with date {msg}");
            return new Response(true);    
        }

        public async Task<Response> SendCancelAppointmentSlotNotification(SendCancelAppointmentSlotNotificationDto model)
        {
            var msg = JsonConvert.SerializeObject(model);
            logger.LogInformation($"Appointment Booking Canceled with date {msg}");

            return new Response(true);
        }
    }
}
