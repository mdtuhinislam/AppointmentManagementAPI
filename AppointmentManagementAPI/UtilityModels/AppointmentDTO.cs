using AppoinmentManagementAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementAPI.Presentation.UtilityModels
{
    public record AppointmentDTO
    (
        int AppointmentId,

        [Required(ErrorMessage = "Patient name is required")] string PatientName ,

        [Required(ErrorMessage = "Patient email/phone number is required as info.")]
         string PatientContactInfo,

        [Required(ErrorMessage = "Appointment date & time is required")]
        DateTime AppointmentDateTime ,

        [Required(ErrorMessage = "Doctor is required"),Range(1,Int32.MaxValue)]
         int DoctorId );
}
