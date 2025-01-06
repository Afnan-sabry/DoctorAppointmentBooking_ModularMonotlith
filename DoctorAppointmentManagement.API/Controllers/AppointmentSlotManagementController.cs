using DoctorAppointmentManagement.Core.Ports.InputPorts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSlotManagementController(IAppointmentSlotService appointmentSlotService) : ControllerBase
    {
        [HttpPut]
        public IActionResult UpdateAppointmentSlotStatus(Guid appointmentId,string status)
        {
            return Ok(appointmentSlotService.UpdateAppointmentSlotStatus(appointmentId,status));
        }
        [HttpGet]
        public IActionResult GetUpcomingAppointmentsByDoctorId(Guid doctorId)
        {
            return Ok(appointmentSlotService.GetUpcomingAppointmentsByDoctorId(doctorId));
        }


    }
}
