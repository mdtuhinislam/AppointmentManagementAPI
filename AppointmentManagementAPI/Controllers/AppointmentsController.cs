using AppoinmentManagementAPI.Domain.Entities;
using AppoinmentManagementAPI.Infrastructure.Database;
using AppointmentManagementAPI.Application.Interfaces.Services.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementAPI.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Add(appointment);
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _service.GetAll();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _service.GetById(id);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] Appointment updatedAppointment)
        {
            var appointment = await _service.Update(updatedAppointment);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _service.Delete(await _service.GetById(id));
            if (appointment == null)
                return NotFound();
            return Ok("Appointment deleted successfully.");
        }
    }
}
