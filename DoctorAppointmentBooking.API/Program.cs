using AppointmentBookingModule.API;
using DoctorAppointmentManagement.Infrastructure.Extensions;
using AppointmentConfirmation.Infrastructure;
using DoctorAvailability.API;
using DoctorAvailability.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using DoctorAvailability.BLL.Interfaces;
using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Debugger.Launch();
try
{
    builder.Services.AddDoctorAvailabilityModule(builder.Configuration);
    builder.Services.AddDoctorAppointmentManagementModule(builder.Configuration);
    builder.Services.AddAppointmentBookingModule(builder.Configuration);
     builder.Services.AddAppointmentConfirmationModule(builder.Configuration);
}
catch (Exception ex)
{

	throw;
}


//builder.Services.AddDbContext<DoctorAvailabilityDBContext>(m => m.UseSqlServer(builder.Configuration
//    .GetConnectionString("Default")));

var app = builder.Build();
 DoctorAvailabilityModuleExtension.Initialize(app);
AppointmentBookingModuleExtension.Initialize(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
