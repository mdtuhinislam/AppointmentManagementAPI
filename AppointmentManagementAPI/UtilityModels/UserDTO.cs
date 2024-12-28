using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementAPI.Presentation.UtilityModels
{
    public record UserDTO([Required(ErrorMessage = "User name is required"),MinLength(3)]string Username, [Required(ErrorMessage = "Password is required"), MinLength(6)] string PasswordHash);
}
