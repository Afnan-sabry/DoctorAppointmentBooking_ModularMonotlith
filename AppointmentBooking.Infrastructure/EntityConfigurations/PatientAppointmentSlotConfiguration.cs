using AppointmentBooking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infrastructure.EntityConfigurations
{
    internal class PatientAppointmentSlotConfiguration : IEntityTypeConfiguration<PatientAppointmentSlot>
    {
        public void Configure(EntityTypeBuilder<PatientAppointmentSlot> entity)
        {
            entity.ToTable(nameof(PatientAppointmentSlot), "AppointmentBooking");
            entity.HasKey(a => a.Id);
            entity.HasOne(a => a.Patient).WithMany(a => a.PatientAppointmentSlots);
        }
    }
}
