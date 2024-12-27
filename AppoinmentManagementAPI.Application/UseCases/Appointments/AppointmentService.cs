using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Repository.Appointments;
using AppointmentManagementAPI.Application.UseCases.Base;

namespace AppointmentManagementAPI.Application.UseCases.Appointments
{
    public class AppointmentService: BaseService<Appointment>
    {
        #region Fields
        protected readonly IAppointmentRepository _repository;
        #endregion
        public AppointmentService(IAppointmentRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
