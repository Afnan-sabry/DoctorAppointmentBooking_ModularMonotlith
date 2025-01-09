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
    public class AppointmentBookingDbContext(DbContextOptions<AppointmentBookingDbContext> options) : ModuleDBContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public DbSet<Patient> Patients {  get; set; }  
        public DbSet<PatientAppointmentSlot> PatientAppointmentSlots {  get; set; }  

    }
}
