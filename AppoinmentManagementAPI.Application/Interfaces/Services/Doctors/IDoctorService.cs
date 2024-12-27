using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Services.Base;

namespace AppointmentManagementAPI.Application.Interfaces.Services.Doctors
{
    public interface IDoctorService: IService<Doctor>
    {
        Task<Doctor> GetById(int id);
    }
}
