using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Domain.Models
{
    public class PatientAppointmentSlot
    {
        public Guid Id { get; set; }
        public Guid AppointmentSlotId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime ReservedAt { get; set; }
        public string Status { get; set; }

        public Patient Patient { get; set; }
    }
}
