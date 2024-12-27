using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Repository.Auth;
using AppointmentManagementAPI.Application.Interfaces.Services.Auth;
using AppointmentManagementAPI.Application.UseCases.Base;
using BCrypt.Net;

namespace AppointmentManagementAPI.Application.UseCases.Auth
{
    public class AuthService : BaseService<User>, IAuthService
    {
        IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository) : base(authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> IsValidUser(User user)
        {
            return await _authRepository.IsValidUser(user);
        }
        public override Task<bool> Add(User entity)
        {
            entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(entity.PasswordHash);
            return base.Add(entity);
        }
    }
}
