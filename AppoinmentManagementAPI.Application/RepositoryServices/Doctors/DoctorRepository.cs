using AppoinmentManagementAPI.Application.Services.Base;
using AppoinmentManagementAPI.Domain.Entities;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Repository.Doctors;

namespace AppoinmentManagementAPI.Application.Services.Doctors
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        AppDbContext db;
        public DoctorRepository(AppDbContext db) : base(db)
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

        public async Task<Doctor> GetById(int id)
        {
            var doctor =  await db.Doctors.FindAsync(id);
            if (doctor is not null)
                return doctor;
            return null!;
        }
    }
}
