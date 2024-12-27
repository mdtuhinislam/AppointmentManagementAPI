using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Repository.Appointments;
using AppointmentManagementAPI.Application.Interfaces.Services.Appointments;
using AppointmentManagementAPI.Application.UseCases.Base;

namespace AppointmentManagementAPI.Application.UseCases.Appointments
{
    public class AppointmentService: BaseService<Appointment>, IAppointmentService
    {
        #region Fields
        protected readonly IAppointmentRepository _repository;
        #endregion
        public AppointmentService(IAppointmentRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Appointment> GetById(int id)
        {
            var appointment = await _repository.GetById(id);
            if (appointment == null)
                return null!;
            return appointment;
        }
    }
}
