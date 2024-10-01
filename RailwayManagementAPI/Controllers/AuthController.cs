using Microsoft.AspNetCore.Mvc;
using RailwayManagementAPI.Models;
using RailwayManagementAPI.Services;

namespace RailwayManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user, string password)
        {
            if (await _authService.UserExists(user.Username))
                return BadRequest("Username already exists");

            var createdUser = await _authService.Register(user, password);
            return Ok(createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.Login(username, password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}