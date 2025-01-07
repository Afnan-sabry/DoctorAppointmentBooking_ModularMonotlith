using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Domain.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientAppointmentSlot> PatientAppointmentSlots { get; set; }
    }
}
