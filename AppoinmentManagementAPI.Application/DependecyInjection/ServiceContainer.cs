﻿using AppoinmentManagementAPI.Application.Services.Appointments;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Repository.Appointments;
using AppointmentManagementAPI.Application.Interfaces.Services.Appointments;
using AppointmentManagementAPI.Application.UseCases.Appointments;
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

            #endregion

            #region Repositories
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            #endregion

            return services;
        }
    }
}
