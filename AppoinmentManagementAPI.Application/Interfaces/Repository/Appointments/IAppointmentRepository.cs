using AppoinmentManagementAPI.Application.Interfaces.Repository.Base;
using AppoinmentManagementAPI.Domain.Entities;

namespace AppointmentManagementAPI.Application.Interfaces.Repository.Appointments
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<Appointment> GetById(int id);
    }
}
