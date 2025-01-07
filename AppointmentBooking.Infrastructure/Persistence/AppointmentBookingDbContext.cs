using AppointmentBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infrastructure.Persistence
{
    public class AppointmentBookingDbContext(DbContextOptions options) : ModuleDBContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
        DbSet<Patient> Patients {  get; set; }  
        DbSet<PatientAppointmentSlot> PatientAppointmentSlots {  get; set; }  

    }
}
