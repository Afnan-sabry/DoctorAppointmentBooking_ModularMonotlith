using AppointmentBooking.Application.Commands.BookAppointment;
using AppointmentBooking.Application.Queries.GetAvailableAppointmentSlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppointmentBookingModule.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentBookingController(IMediator mediatr) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> BookSlot(BookAppointmentCommand command)
        {
            return Ok ( await mediatr.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAvailableAppointmentSlots()
        {
            return Ok(await mediatr.Send(new GetAvailableAppointmentSlotsQuery()));
        }


    }

    public class WeatherForecasts
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
