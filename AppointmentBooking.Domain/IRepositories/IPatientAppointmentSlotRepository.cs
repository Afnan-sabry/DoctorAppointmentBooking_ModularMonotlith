using AppointmentBooking.Domain.Models;
using Shared.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Domain.IRepositories
{
    public interface IPatientAppointmentSlotRepository
    {
        Task<bool> BookAppointmentSlot(PatientAppointmentSlot patientAppointmentSlot);
        Task<List<PatientAppointmentSlot>> GetPatientAppointmentSlots();
        Task<bool> UpdateAppointmentSlotStatus(Guid slotId, string status);


    }
}
