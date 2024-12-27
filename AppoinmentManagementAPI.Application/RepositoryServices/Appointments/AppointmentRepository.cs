using AppoinmentManagementAPI.Application.Services.Base;
using AppoinmentManagementAPI.Domain.Entities;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Repository.Appointments;

namespace AppoinmentManagementAPI.Application.Services.Appointments
{
    public class AppointmentRepository:BaseRepository<Appointment>, IAppointmentRepository
    {
        AppDbContext db;
        public AppointmentRepository(AppDbContext db): base(db)
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

        public async Task<Appointment> GetById(int id)
        {
            var appointment =  await db.Appointments.FindAsync(id);
            if (appointment is not null)
                return appointment;
            return null!;
        }
    }
}
