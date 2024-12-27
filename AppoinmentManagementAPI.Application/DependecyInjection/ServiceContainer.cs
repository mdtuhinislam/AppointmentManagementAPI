using AppoinmentManagementAPI.Application.Services.Appointments;
using AppoinmentManagementAPI.Application.Services.Doctors;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Repository.Appointments;
using AppointmentManagementAPI.Application.Interfaces.Repository.Doctors;
using AppointmentManagementAPI.Application.Interfaces.Services.Appointments;
using AppointmentManagementAPI.Application.Interfaces.Services.Doctors;
using AppointmentManagementAPI.Application.UseCases.Appointments;
using AppointmentManagementAPI.Application.UseCases.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppoinmentManagementAPI.Application.DependecyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            //Add database dependency
            #region Database
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString("AppConnectionString"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            #endregion

            //Add dependency injection (DI)
            #region Services
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorService, DoctorService>();

            #endregion

            #region Repositories
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            #endregion

            return services;
        }
    }
}
