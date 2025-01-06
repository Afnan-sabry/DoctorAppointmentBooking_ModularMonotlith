using DoctorAppointmentManagement.Core.Domain.Models;
using DoctorAppointmentManagement.Core.Ports.OutputPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Adapters.Adapters.OutputAdapters
{
    internal class AppointmentSlotRepository : IAppointmentSlotRepository
    {
        Task<List<AppointmentSlot>> IAppointmentSlotRepository.GetUpcomingAppointmentsByDoctorId(Guid doctorId)
        {
            throw new NotImplementedException();
        }

        Task IAppointmentSlotRepository.UpdateAppointmentSlotStatus(Guid appointmentdSlotId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
