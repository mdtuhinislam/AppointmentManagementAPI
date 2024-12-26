using AppoinmentManagementAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppoinmentManagementAPI.Application.DependecyInjection
{
    public static class AddInfrustructureServices
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
            
            #endregion

            #region Repositories
            
            #endregion

            return services;
        }
    }
}
