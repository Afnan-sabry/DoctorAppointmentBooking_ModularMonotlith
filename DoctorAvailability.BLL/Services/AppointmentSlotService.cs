﻿using DoctorAvailability.BLL.Dtos;
using DoctorAvailability.BLL.Interfaces;
using Shared.Infrastructure.Wrappers;
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
                AppointmentDate = model.AppointmentDate,
                IsReserved = false,
            };
            await appointmentSlotRepository.AddAppointmentSlot(data);
            return new Response<Guid>(data.Id, true);

        }

        public async Task<Response<List<GetAppointmentSlotsResponseDto>>> GetDoctorAppointmentSlots(Guid doctorId)
        {
            var doctorSlots = await appointmentSlotRepository.GetDoctorAppointmentSlots(doctorId);
            List<GetAppointmentSlotsResponseDto> data = [];

            doctorSlots.ForEach(slot =>
             data.Add(new GetAppointmentSlotsResponseDto()
             {
                 Id = slot.Id,
                 DoctorId = slot.DoctorId,
                 Cost = slot.Cost,
                 AppointmentDate = slot.AppointmentDate,
                 IsReserved = slot.IsReserved,

             }));
            return new Response<List<GetAppointmentSlotsResponseDto>>(data, true);

        }
        public async Task<bool> BookAppointmentSlot(Guid appointmentId)
        {
            return await appointmentSlotRepository.BookAppointmentSlotById(appointmentId);

        }


        public async Task<Response<List<GetAppointmentSlotsResponseDto>>> GetAvailableAppointmentSlots()
        {
            var doctorSlots = await appointmentSlotRepository.GetAvailableAppointmentSlots();
            List<GetAppointmentSlotsResponseDto> data = [];

            doctorSlots.ForEach(slot =>
             data.Add(new GetAppointmentSlotsResponseDto()
             {
                 Id = slot.Id,
                 DoctorId = slot.DoctorId,
                 Cost = slot.Cost,
                 AppointmentDate = slot.AppointmentDate,
                 IsReserved = slot.IsReserved,

             }));
            return new Response<List<GetAppointmentSlotsResponseDto>>(data, true);

        }
        public async Task<Response<List<GetAppointmentSlotsResponseDto>>> GetDoctorUpcommingAppointmentSlots(Guid doctorId)
        {
            var doctorSlots = await appointmentSlotRepository.GetDoctorUpcommingAppointmentSlots(doctorId);
            List<GetAppointmentSlotsResponseDto> data = [];

            doctorSlots.ForEach(slot =>
             data.Add(new GetAppointmentSlotsResponseDto()
             {
                 Id = slot.Id,
                 DoctorId = slot.DoctorId,
                 Cost = slot.Cost,
                 AppointmentDate = slot.AppointmentDate,
                 IsReserved = slot.IsReserved,

             }));
            return new Response<List<GetAppointmentSlotsResponseDto>>(data, true);

        }

    }
}
