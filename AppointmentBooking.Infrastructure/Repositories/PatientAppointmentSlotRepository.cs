using AppointmentBooking.Domain.IRepositories;
using AppointmentBooking.Domain.Models;
using AppointmentBooking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infrastructure.Repositories
{
    internal class PatientAppointmentSlotRepository(AppointmentBookingDbContext context) : IPatientAppointmentSlotRepository
    {
        public async Task<bool> BookAppointmentSlot(PatientAppointmentSlot patientAppointmentSlot)
        {
            context.Add(patientAppointmentSlot);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<List<PatientAppointmentSlot>> GetPatientAppointmentSlots()
        {
            return await context.PatientAppointmentSlots.ToListAsync();
        }
        public async Task<bool> UpdateAppointmentSlotStatus(Guid slotId, string status)
        {
            var slot = await context.PatientAppointmentSlots.FirstOrDefaultAsync(a => a.Id == slotId);
            if (slot == null) return false;
            slot.Status = status;
            await context.SaveChangesAsync();

            return true;
        }
    }
}
