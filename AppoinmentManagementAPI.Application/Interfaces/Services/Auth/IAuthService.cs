using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Services.Base;

namespace AppointmentManagementAPI.Application.Interfaces.Services.Auth
{
    public interface IAuthService : IService<User>
    {
        Task<User> IsValidUser(User user);
    }
}
