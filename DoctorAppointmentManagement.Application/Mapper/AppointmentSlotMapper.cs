using DoctorAppointmentManagement.Core.Domain.Models;
using DoctorAppointmentManagement.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Application.Mapper
{
    public static class AppointmentSlotMapper
    {
        public static AppointmentSlotDto ToDto(this AppointmentSlot appointment)
        {
            return new AppointmentSlotDto
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                IsReserved = appointment.IsReserved,
                Cost = appointment.Cost,
            };
        }



    }
}
