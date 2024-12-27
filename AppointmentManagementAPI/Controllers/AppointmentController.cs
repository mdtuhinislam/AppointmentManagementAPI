using System.Net;
using AppoinmentManagementAPI.Domain.Entities;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Services.Appointments;
using AppointmentManagementAPI.Presentation.UtilityModels;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementAPI.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
                return CustomResult("Invalid data!", HttpStatusCode.BadRequest);
            var _appointment = new Appointment
            {
                PatientName = appointment.PatientName,
                PatientContactInfo = appointment.PatientContactInfo,
                AppointmentDateTime = appointment.AppointmentDateTime,
                DoctorId = appointment.DoctorId
            };
            var isAdded = await _service.Add(_appointment);
            if (!isAdded)
                return CustomResult("Data not added!", HttpStatusCode.InternalServerError);
            return CustomResult("Created", appointment, HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _service.GetAll();
            if (appointments is null || appointments.Count() == 0)
                return CustomResult("Data not found!", HttpStatusCode.NotFound);
            return CustomResult("Data found!", appointments, HttpStatusCode.NotFound);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _service.GetById(id);
            if (appointment == null)
                return CustomResult("Data not found!", HttpStatusCode.NotFound);

            return CustomResult("Data found!", appointment, HttpStatusCode.NotFound);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentDTO updatedAppointment)
        {
            if(!ModelState.IsValid)
                return CustomResult("Invalid data!", HttpStatusCode.BadRequest);

            var appointment = await _service.GetById(updatedAppointment.AppointmentId);
            if (appointment == null)
                return CustomResult("Data not found!", HttpStatusCode.NotFound);

            var _appointment = new Appointment
            {
                PatientName = updatedAppointment.PatientName,
                PatientContactInfo = updatedAppointment.PatientContactInfo,
                AppointmentDateTime = updatedAppointment.AppointmentDateTime,
                DoctorId = updatedAppointment.DoctorId
            };
            var isUpdated = await _service.Update(_appointment);
            if (!isUpdated)
                return CustomResult("Data not updated!", HttpStatusCode.InternalServerError);

            return CustomResult("Appointment updated successfully.", updatedAppointment, HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var isDeleted = await _service.Delete(await _service.GetById(id));
            if (!isDeleted)
                return CustomResult("Data not deleted!", HttpStatusCode.InternalServerError);
            return CustomResult("Appointment deleted successfully.", HttpStatusCode.OK);
        }
    }
}
