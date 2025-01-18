﻿using AppointmentBooking.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Commands.UpdateAppointmentStatus
{
    public record UpdateAppointmentStatusCommand(Guid AppointmentSlotId ,string Status):IRequest;
    public class UpdateAppointmentStatusCommandHandler(IPatientAppointmentSlotRepository patientAppointmentSlotRepository) : IRequestHandler<UpdateAppointmentStatusCommand>
    {
        public Task Handle(UpdateAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
