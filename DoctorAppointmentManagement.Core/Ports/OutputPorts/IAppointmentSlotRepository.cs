using DoctorAppointmentManagement.Core.Domain.Models;
using DoctorAppointmentManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Core.Ports.OutputPorts
{
    public interface IAppointmentSlotRepository
    {
        Task<List<AppointmentSlot>> GetUpcomingAppointmentsByDoctorId(Guid doctorId);
        Task UpdateAppointmentSlotStatus(Guid appointmentdSlotId, string status);
    }
}
