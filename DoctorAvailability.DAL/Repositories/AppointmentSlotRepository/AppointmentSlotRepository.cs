using DoctorAvailability.DAL.Models;
using DoctorAvailability.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.DAL.Repositories.AppointmentSlotRepository
{
    public class AppointmentSlotRepository(DoctorAvailabilityDBContext dbContext) : IAppointmentSlotRepository
    {

        public async Task<Guid> AddAppointmentSlot(AppointmentSlot model)
        {
            dbContext.AppointmentSlots.Add(model);
            await dbContext.SaveChangesAsync();
            return model.Id;
        }

        public async Task<List<AppointmentSlot>> GetDoctorAppointmentSlots(Guid doctorId)
        {
            var data = await dbContext.AppointmentSlots.Where(a => a.Id == doctorId).ToListAsync();
            return data;
        }
        public async Task<List<AppointmentSlot>> GetAvailableAppointmentSlots()
        {
            var dateNow = DateTime.Now.Date;

            var data = await dbContext.AppointmentSlots.Where(a => a.AppointmentDate >= dateNow && !a.IsReserved).ToListAsync();
            return data;
        }
        public async Task<List<AppointmentSlot>> GetDoctorUpcommingAppointmentSlots(Guid doctorId)
        {
            var dateNow = DateTime.Now.Date;
            var data = await dbContext.AppointmentSlots.Where(a => a.Id == doctorId && a.AppointmentDate >= dateNow).ToListAsync();
            return data;
        }

        public async Task<bool> BookAppointmentSlotById(Guid slotId)
        {
            var slot = await dbContext.AppointmentSlots.FirstOrDefaultAsync(a => a.Id == slotId);
            if (slot == null) return false;
            if (slot.IsReserved) return false;
            slot.IsReserved = true;
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAppointmentSlotStatus(Guid slotId,int status)
        {
            var slot = await dbContext.AppointmentSlots.FirstOrDefaultAsync(a => a.Id == slotId);
            if (slot == null) return false;
            slot.IsReserved = false;
            slot.Status = status;
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
