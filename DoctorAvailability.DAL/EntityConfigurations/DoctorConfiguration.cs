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
    public sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> entity)
        {
            entity.ToTable(nameof(Doctor), "DoctorAvailability");
            entity.HasKey(a => a.Id);

        }
    }
}
