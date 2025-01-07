
using AppointmentBooking.Domain.IRepositories;
using AppointmentBooking.Domain.Models;
using MediatR;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Commands.BookAppointment
{
    internal class BookAppointmentCommandHandler(IPatientAppointmentSlotRepository patientAppointmentSlotRepository) : IRequestHandler<BookAppointmentCommand,Response>
    {
        public async Task<Response> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
        {
            PatientAppointmentSlot slot = new()
            {
                Id = new Guid(),
                PatientId = request.PatientId,
                AppointmentSlotId = request.AppointmentId
            };
          var response= await patientAppointmentSlotRepository.BookAppointmentSlot(slot);
            return new Response(response);
        }
    }
}
