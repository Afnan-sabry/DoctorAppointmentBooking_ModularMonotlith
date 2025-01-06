using DoctorAppointmentManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Core.Ports.InputPorts
{
    public interface IAppointmentSlotService
    {
        Task<List<AppointmentSlotDto>> GetUpcomingAppointmentsByDoctorId(Guid doctorId);
        Task UpdateAppointmentSlotStatus( Guid appointmentdSlotId, string status);
    }
}
