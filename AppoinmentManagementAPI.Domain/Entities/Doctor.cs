using System.ComponentModel.DataAnnotations;

namespace AppoinmentManagementAPI.Domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; }
    }
}
