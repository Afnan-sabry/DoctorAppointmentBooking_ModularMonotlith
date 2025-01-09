using DoctorAvailability.DAL.Models;
using DoctorAvailability.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
           var data= await dbContext.AppointmentSlots.Where(a=>a.Id==doctorId).ToListAsync();
            return data;
        }
    }
}
