using MediatR;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Commands.BookAppointment
{
    public record BookAppointmentCommand(Guid AppointmentId,Guid PatientId):IRequest<Response>;
}
