using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Queries.GetAvailableAppointmentSlots
{
    public class GetAvailableAppointmentSlotsResponse
    {
        public Guid AppointmentSlotId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Guid DoctorId { get; set; }
        public decimal Cost { get; set; }
    }
}
