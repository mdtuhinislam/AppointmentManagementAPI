using AppoinmentManagementAPI.Application.Services.Base;
using AppoinmentManagementAPI.Domain.Entities;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Repository.Auth;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementAPI.Application.RepositoryServices.Auth
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        AppDbContext db;
        public AuthRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }
        public AppDbContext Db
        {
            get
            {
                return db;
            }
            set
            {
                 db = value;
            }
        }

        public async Task<User> IsValidUser(User user)
        {
            var _user = await db.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (_user is not null)
            {
                if(BCrypt.Net.BCrypt.Verify(user.PasswordHash, _user.PasswordHash))
                    return user;
                return null!;
            }
            return null!;
        }
    }
}
