using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Repository.Appointments;
using AppointmentManagementAPI.Application.Interfaces.Repository.Doctors;
using AppointmentManagementAPI.Application.Interfaces.Services.Appointments;
using AppointmentManagementAPI.Application.Interfaces.Services.Doctors;
using AppointmentManagementAPI.Application.UseCases.Base;

namespace AppointmentManagementAPI.Application.UseCases.Doctors
{ 
    public class DoctorService : BaseService<Doctor>, IDoctorService
    {
        #region Fields
        protected readonly IDoctorRepository _repository;
        #endregion
        public DoctorService(IDoctorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Doctor> GetById(int id)
        {
            var doctor = await _repository.GetById(id);
            if (doctor == null)
                return null!;
            return doctor;
        }
    }
}
