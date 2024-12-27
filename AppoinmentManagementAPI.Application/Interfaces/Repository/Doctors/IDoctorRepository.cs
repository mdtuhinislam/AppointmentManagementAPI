using AppoinmentManagementAPI.Application.Interfaces.Repository.Base;
using AppoinmentManagementAPI.Domain.Entities;

namespace AppointmentManagementAPI.Application.Interfaces.Repository.Doctors
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor> GetById(int id);
    }
}
