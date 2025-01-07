using AppointmentBooking.Application.Commands.BookAppointment;
using AppointmentBooking.Application.Queries.GetAvailableAppointmentSlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBookingModule.API.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class AppointmentBookingController(IMediator mediatr) : ControllerBase
    {
        [HttpPost]
        public IActionResult BookSlot(BookAppointmentCommand command)
        {
            return Ok(mediatr.Send(command));
        }
        [HttpGet]
        public IActionResult GetAvailableAppointmentSlots(GetAvailableAppointmentSlotsQuery query)
        {
            return Ok(mediatr.Send(query));
        }


    }
}
