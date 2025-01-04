using DoctorAvailability.DAL.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAvailability.DAL.Extensions;
using DoctorAvailability.DAL.Repositories.AppointmentSlotRepository;
using DoctorAvailability.BLL.Interfaces;
using DoctorAvailability.BLL.Services;
namespace DoctorAvailability.API
{
    public static class DoctorAvailabilityModuleExtension
    {
        public static IServiceCollection AddDoctorAvailabilityModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDoctorAvailabilityInfrastructure(config);
            services.AddScoped<IAppointmentSlotRepository, AppointmentSlotRepository>();
            services.AddScoped<IAppointmentSlotService, AppointmentSlotService>();
            return services;
        }
    }
}
