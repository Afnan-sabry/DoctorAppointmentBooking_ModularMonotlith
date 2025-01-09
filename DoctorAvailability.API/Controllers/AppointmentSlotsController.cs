
using DoctorAvailability.BLL.Dtos;
using DoctorAvailability.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace DoctorAvailability.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentSlotsController(IAppointmentSlotService appointmentSlotService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAppointmentSlot(AddAppointmentSlotDto model)
        {
            return Ok(await appointmentSlotService.AddAppointmentSlot(model));
        }
        [HttpGet]
        public async Task< IActionResult> GetDoctorAppointmentSlots(Guid doctorId)
        {
            return Ok(await appointmentSlotService.GetDoctorAppointmentSlots(doctorId));
        }


    }
}
