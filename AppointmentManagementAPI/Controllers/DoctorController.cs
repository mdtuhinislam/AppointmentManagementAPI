using System.Net;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagementAPI.Application.Interfaces.Services.Doctors;
using AppoinmentManagementAPI.Domain.Entities;

namespace AppointmentManagementAPI.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
                return CustomResult("Invalid data!", HttpStatusCode.BadRequest);

            var isAdded = await _service.Add(doctor);
            if (!isAdded)
                return CustomResult("Data not added!", HttpStatusCode.InternalServerError);
            return CustomResult("Created", doctor, HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctor()
        {
            var doctors = await _service.GetAll();
            if (doctors is null || doctors.Count() == 0)
                return CustomResult("Data not found!", HttpStatusCode.NotFound);
            return CustomResult("Data found!", doctors, HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _service.GetById(id);
            if (doctor == null)
                return CustomResult("Data not found!", HttpStatusCode.NotFound);

            return CustomResult("Data found!", doctor, HttpStatusCode.NotFound);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor([FromBody] Doctor doctor)
        {
            var isUpdated = await _service.Update(doctor);
            if (!isUpdated)
                return CustomResult("Data not updated!", HttpStatusCode.InternalServerError);
            return CustomResult("Appointment updated successfully.", HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var isDeleted = await _service.Delete(await _service.GetById(id));
            if (!isDeleted)
                return CustomResult("Data not deleted!", HttpStatusCode.InternalServerError);
            return CustomResult("Doctor deleted successfully.", HttpStatusCode.OK);
        }
    }
}
