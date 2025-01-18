using DoctorAvailability.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.DAL.Repositories.AppointmentSlotRepository
{
    public interface IAppointmentSlotRepository
    {
        public Task<Guid> AddAppointmentSlot(AppointmentSlot model);
        Task<bool> BookAppointmentSlotById(Guid slotId);
        Task<List<AppointmentSlot>> GetAvailableAppointmentSlots();
        public Task<List<AppointmentSlot>> GetDoctorAppointmentSlots(Guid doctorId);
        Task<List<AppointmentSlot>> GetDoctorUpcommingAppointmentSlots(Guid doctorId);
    }
}
