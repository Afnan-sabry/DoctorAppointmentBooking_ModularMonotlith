using AppointmentBooking.Application.Dtos;
using AppointmentBooking.Application.ExternalServiceInterfaces;
using DoctorAvailability.BLL.Interfaces;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infrastructure.Integration.Services
{
    internal class BookingAppointmentSlotService(IAppointmentSlotService appointmentSlotService) : IBookingAppointmentSlotService
    {
        public async Task<Response<List<AvailableAppointmentSlotDto>>> GetAvailableAppointmentSlots()
        {
            var response=await appointmentSlotService.GetAvailableAppointmentSlots();
            if(response == null || !response.Succeeded)
                return new Response<List<AvailableAppointmentSlotDto>>([], false, response?.Message);

           List< AvailableAppointmentSlotDto> data = [];
            response.Data.ForEach(slot =>
           data.Add(new AvailableAppointmentSlotDto()
           {
               Id = slot.Id,
               DoctorId = slot.DoctorId,
               Cost = slot.Cost,
               AppointmentDate = slot.AppointmentDate,
               IsReserved = slot.IsReserved,

           }));
            return new Response<List<AvailableAppointmentSlotDto>>(data,true,"");
        }
    }
}
