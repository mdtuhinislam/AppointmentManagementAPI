using AppoinmentManagementAPI.Application.Interfaces.Repository.Base;
using AppoinmentManagementAPI.Domain.Entities;

namespace AppointmentManagementAPI.Application.Interfaces.Repository.Auth
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<User> IsValidUser(User user);
    }
}
