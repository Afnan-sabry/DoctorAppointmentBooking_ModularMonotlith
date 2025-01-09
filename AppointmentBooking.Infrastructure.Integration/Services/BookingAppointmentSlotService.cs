using AppointmentBooking.Application.Dtos;
using AppointmentBooking.Application.ExternalServiceInterfaces;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infrastructure.Integration.Services
{
    internal class BookingAppointmentSlotService : IBookingAppointmentSlotService
    {
        public Task<Response<List<AvailableAppointmentSlotDto>>> GetAvailableAppointmentSlots()
        {
           return Task.FromResult( new Response<List<AvailableAppointmentSlotDto>>([],true,""));
        }
    }
}
