using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.DAL.Models
{
    public class Doctor:BaseEntity<Guid>
    {
        public string Name { get; set; }
        public ICollection<AppointmentSlot> AppointmentSlots {  get; set; }
    }
}
