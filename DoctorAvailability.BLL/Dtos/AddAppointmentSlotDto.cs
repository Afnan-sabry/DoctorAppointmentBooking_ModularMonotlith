using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.BLL.Dtos
{
    public class AddAppointmentSlotDto
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Guid DoctorId { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
