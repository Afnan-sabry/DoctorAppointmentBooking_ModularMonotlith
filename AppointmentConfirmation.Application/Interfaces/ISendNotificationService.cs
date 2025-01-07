using AppointmentConfirmation.Application.Dtos;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentConfirmation.Application.Interfaces
{
    public interface ISendNotificationService
    {
        Task<Response> SendBookingAppointmentSlotNotification(SendBookingAppointmentSlotNotification model);
        Task<Response> SendCancelAppointmentSlotNotification(SendCancelAppointmentSlotNotificationDto model);
    }
}
