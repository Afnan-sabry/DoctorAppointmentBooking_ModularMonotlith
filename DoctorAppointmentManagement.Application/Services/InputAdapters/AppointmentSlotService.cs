using DoctorAppointmentManagement.Application.Mapper;
using DoctorAppointmentManagement.Core.Dtos;
using DoctorAppointmentManagement.Core.Ports.InputPorts;
using DoctorAppointmentManagement.Core.Ports.OutputPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorAppointmentManagement.Application.Services.InputAdapters
{
    public class AppointmentSlotService(IAppointmentSlotRepository appointmentSlotService) : IAppointmentSlotService
    {
        public async Task<List<AppointmentSlotDto>> GetUpcomingAppointmentsByDoctorId(Guid doctorId)
        {
            var slots=await appointmentSlotService.GetUpcomingAppointmentsByDoctorId(doctorId);

            return slots.Select(a => a.ToDto()).ToList();   
        }

        public async Task UpdateAppointmentSlotStatus(Guid appointmentdSlotId, string status)
        {
          await appointmentSlotService.UpdateAppointmentSlotStatus(appointmentdSlotId,status);

        }
    }
}
