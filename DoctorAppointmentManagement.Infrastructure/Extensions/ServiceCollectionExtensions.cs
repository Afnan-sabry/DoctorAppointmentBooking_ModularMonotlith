using DoctorAppointmentManagement.Adapters.Adapters.OutputAdapters;
using DoctorAppointmentManagement.Core.Ports.InputPorts;
using DoctorAppointmentManagement.Core.Ports.OutputPorts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDoctorAppointmentManagementInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            //services
            //    .AddDatabaseContext<DoctorAvailabilityDBContext>(config);
            services.AddScoped<IAppointmentSlotRepository, AppointmentSlotRepository>();
            return services;
        }
    }
}
