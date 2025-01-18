
using AppointmentBooking.Application.ExternalServiceInterfaces;
using AppointmentBooking.Domain.IRepositories;
using MediatR;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Queries.GetAvailableAppointmentSlots
{
    public class GetAvailableAppointmentSlotsQueryHandler(IBookingAppointmentSlotService bookingAppointmentSlotService, IPatientAppointmentSlotRepository patientAppointmentSlotRepository) : IRequestHandler<GetAvailableAppointmentSlotsQuery, Response<List<GetAvailableAppointmentSlotsResponse>>>
    {


        public async Task<Response<List<GetAvailableAppointmentSlotsResponse>>> Handle(GetAvailableAppointmentSlotsQuery request, CancellationToken cancellationToken)
        {
            var availableSlotsResponse = await bookingAppointmentSlotService.GetAvailableAppointmentSlots();
            if (!availableSlotsResponse.Succeeded) return new Response<List<GetAvailableAppointmentSlotsResponse>>([], false, availableSlotsResponse.Message);

            var availableSlots = availableSlotsResponse.Data.Select(x => new GetAvailableAppointmentSlotsResponse
            {
                AppointmentSlotId = x.Id,
                DoctorId = x.DoctorId,
                Cost = x.Cost,
                AppointmentDate = x.AppointmentDate,
            }).ToList();
            return  new Response<List<GetAvailableAppointmentSlotsResponse>>(availableSlots, true, string.Empty);
        }
    }
}
