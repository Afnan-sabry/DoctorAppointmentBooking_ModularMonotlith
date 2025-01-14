using MediatR;
using Shared.Messaging.Contracts;

using Shared.Messaging.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Commands.BookAppointment
{
    public record AppointmentBookedNotification(AppointmentSlotBooked AppointmentSlotBooked) :INotification;
    public class AppointmentBookedNotificationHandler(AppointmentBookedNotification notification) : INotificationHandler<AppointmentBookedNotification>
    {
        public async Task Handle(AppointmentBookedNotification notification, CancellationToken cancellationToken)
        {
            var rabbitMQPublisher = new RabbitMqPublisher();
            await rabbitMQPublisher.PublishMessageAsync<AppointmentSlotBooked>(notification.AppointmentSlotBooked, RabbitMQQueues.AppointmentBooked);
        }
    }

}
