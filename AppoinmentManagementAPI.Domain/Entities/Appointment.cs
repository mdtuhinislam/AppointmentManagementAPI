using System.ComponentModel.DataAnnotations;

namespace AppoinmentManagementAPI.Domain.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string PatientContactInfo { get; set; }

        [Required]
        public DateTime AppointmentDateTime { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
