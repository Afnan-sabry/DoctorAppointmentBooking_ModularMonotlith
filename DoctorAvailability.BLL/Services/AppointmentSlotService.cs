using DoctorAvailability.BLL.Dtos;
using DoctorAvailability.BLL.Interfaces;
using DoctorAvailability.BLL.Wrappers;
using DoctorAvailability.DAL.Models;
using DoctorAvailability.DAL.Repositories.AppointmentSlotRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.BLL.Services
{
    public class AppointmentSlotService(IAppointmentSlotRepository appointmentSlotRepository) : IAppointmentSlotService
    {
        public async Task<Response<Guid>> AddAppointmentSlot(AddAppointmentSlotDto model)
        {
            var data = new AppointmentSlot()
            {
                Id = new Guid(),
                DoctorId = model.DoctorId,
                Cost = model.Cost,
                From = model.From,
                To = model.To,
                IsReserved = false,
            };
           await appointmentSlotRepository.AddAppointmentSlot(data);
            return new Response<Guid>(data.Id, true);

        }

        public async Task<Response<List<GetAppointmentSlotsResponseDto>>> GetDoctorAppointmentSlots(Guid doctorId)
        {
            var doctorSlots=await appointmentSlotRepository.GetDoctorAppointmentSlots(doctorId);
            List<GetAppointmentSlotsResponseDto> data = [];

               doctorSlots.ForEach(slot =>
                data.Add( new GetAppointmentSlotsResponseDto()
                {
                    Id = slot.Id,
                    DoctorId = slot.DoctorId,
                    Cost = slot.Cost,
                    From = slot.From,
                    To = slot.To,
                    IsReserved = slot.IsReserved,

                }));
            return new Response<List<GetAppointmentSlotsResponseDto>> (data,true);

        }
    }
}
