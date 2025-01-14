using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messaging.Contracts
{
    public class AppointmentSlotBooked
    {
        public Guid AppointmentSlotId { get; set; }
        public Guid PatientId { get; set; }
    }
}
