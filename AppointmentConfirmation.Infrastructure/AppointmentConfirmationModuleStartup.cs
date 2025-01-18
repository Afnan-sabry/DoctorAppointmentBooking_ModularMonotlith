
using Shared.Messaging.Contracts;
using Shared.Messaging.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentConfirmation.Infrastructure
{
    public class AppointmentConfirmationModuleStartup
    {
     
        public static async Task Initialize()
        {
            RabbitMqSubscriber _subscriber = new();
            await _subscriber.Subscribe<AppointmentSlotBooked>(
                 RabbitMQQueues.AppointmentBooked,
                 message =>
                 {
                     Console.WriteLine($"appointment booking received: {message.AppointmentSlotId}");
                     // Process the message
                 });
        }
    }
}
