﻿using DoctorAvailability.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.DAL.Persistence
{
    public  class DoctorAvailabilityDBContext(DbContextOptions<DoctorAvailabilityDBContext> options) : ModuleDBContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
     
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<AppointmentSlot> AppointmentSlots { get; set; }
    }
}
