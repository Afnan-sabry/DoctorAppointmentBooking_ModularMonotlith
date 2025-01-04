
using DoctorAvailability.BLL.Dtos;
using DoctorAvailability.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace DoctorAvailability.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSlotsController(IAppointmentSlotService appointmentSlotService) : ControllerBase
    {
        [HttpPost]
        public IActionResult AddAppointmentSlot(AddAppointmentSlotDto model)
        {
            return Ok(appointmentSlotService.AddAppointmentSlot(model));
        }
        [HttpGet]
        public IActionResult GetDoctorAppointmentSlots(Guid doctorId)
        {
            return Ok(appointmentSlotService.GetDoctorAppointmentSlots(doctorId));
        }


    }
}
