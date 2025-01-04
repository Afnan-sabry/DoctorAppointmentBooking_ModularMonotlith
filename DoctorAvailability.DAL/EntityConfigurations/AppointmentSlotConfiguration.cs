using DoctorAvailability.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.DAL.EntityConfigurations
{
    public sealed class AppointmentSlotConfiguration : IEntityTypeConfiguration<AppointmentSlot>
    {
        public void Configure(EntityTypeBuilder<AppointmentSlot> entity)
        {
            entity.ToTable(nameof(AppointmentSlot), "DoctorAvailability");
            entity.HasKey(a => a.Id);
            entity.HasOne(a => a.Doctor).WithMany(a => a.AppointmentSlots);
        }
    }
}
