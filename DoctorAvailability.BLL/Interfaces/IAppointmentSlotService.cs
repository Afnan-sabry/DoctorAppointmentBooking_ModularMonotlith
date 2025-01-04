using DoctorAvailability.BLL.Dtos;
using DoctorAvailability.BLL.Wrappers;
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
        public  Task<Response<List<GetAppointmentSlotsResponseDto>>> GetDoctorAppointmentSlots(Guid doctorId);
    }
}
