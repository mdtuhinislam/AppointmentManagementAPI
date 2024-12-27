using System.Net;
using AppoinmentManagementAPI.Domain.Entities;
using AppointmentManagementAPI.Application.Interfaces.Services.Auth;
using AppointmentManagementAPI.Presentation.HelperClass;
using AppointmentManagementAPI.Presentation.UtilityModels;
using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagementAPI.Presentation.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            var users = await _authService.GetAll();
            if (users.Any(u => u.Username == user.Username))
                return CustomResult("Username already exists, try another!",HttpStatusCode.BadRequest);

            if(await _authService.Add(new User { Username = user.Username, PasswordHash = user.PasswordHash}))
                return CustomResult("User registered successfully.", user.Username, HttpStatusCode.Created);

            return CustomResult("User creation failed!, please try again!",HttpStatusCode.InternalServerError);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            User _user = new User {UserId = 0 , Username = user.Username, PasswordHash=user.PasswordHash };
            var dbUser = await _authService.IsValidUser(_user);
            if (dbUser == null)
                return CustomResult("Invalid username or password.", HttpStatusCode.Unauthorized);

            var token = JWTFactory.GenerateJwtToken(dbUser, _configuration);
            return Ok(new { Token = token });
        }

        
    }
}
