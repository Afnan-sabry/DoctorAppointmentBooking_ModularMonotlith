using DoctorAvailability.BLL.Dtos;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.BLL.Interfaces
{
    public interface IAppointmentSlotService
    {
        public  Task<Response<Guid>> AddAppointmentSlot(AddAppointmentSlotDto model);
        Task<bool> BookAppointmentSlot(Guid appointmentId);
        Task<Response<List<GetAppointmentSlotsResponseDto>>> GetAvailableAppointmentSlots();
        public  Task<Response< List<GetAppointmentSlotsResponseDto>>> GetDoctorAppointmentSlots(Guid doctorId);
        Task<Response<List<GetAppointmentSlotsResponseDto>>> GetDoctorUpcommingAppointmentSlots(Guid doctorId);
    }
}
