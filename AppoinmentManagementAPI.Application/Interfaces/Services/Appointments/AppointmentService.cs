using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Services.Base;

namespace AppointmentManagementAPI.Application.Interfaces.Services.Appointments
{
    public interface IAppointmentService : IService<Appointment>
    {
        public Task<Appointment> GetById(int id);
    }
}
