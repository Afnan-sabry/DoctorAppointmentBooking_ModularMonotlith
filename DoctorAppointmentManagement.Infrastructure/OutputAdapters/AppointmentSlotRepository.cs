using DoctorAppointmentManagement.Core.Domain.Enums;
using DoctorAppointmentManagement.Core.Domain.Models;
using DoctorAppointmentManagement.Core.Ports.OutputPorts;
using Shared.Messaging.Contracts;

using Shared.Messaging.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Adapters.Adapters.OutputAdapters
{
    internal class AppointmentSlotRepository(DoctorAvailability.BLL.Interfaces.IAppointmentSlotService appointmentSlotService) : IAppointmentSlotRepository
    {
       public async Task<List<AppointmentSlot>>GetUpcomingAppointmentsByDoctorId(Guid doctorId)
        {
            var response = await appointmentSlotService.GetDoctorUpcommingAppointmentSlots(doctorId);
            if (response == null || !response.Succeeded)
                return [];

            List<AppointmentSlot> data = [];
            response.Data.ForEach(slot =>
           data.Add(new AppointmentSlot()
           {
               Id = slot.Id,
               DoctorId = slot.DoctorId,
               Cost = slot.Cost,
               AppointmentDate = slot.AppointmentDate,
               IsReserved = slot.IsReserved,

           }));
            return data;
        }

      public async Task UpdateAppointmentSlotStatus(Guid appointmentdSlotId, AppointmentSlotStatus status)
        {
           RabbitMqPublisher rabbitMQPublisher = new();
            await rabbitMQPublisher.PublishMessageAsync<AppointmentSlotStatusUpdated>(new() {AppointmentSlotId= appointmentdSlotId,Status= (int)status }, RabbitMQQueues.AppointmentStatusUpdated);
           

        }
    }
}
