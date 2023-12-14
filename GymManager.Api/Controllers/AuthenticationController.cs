using GymManager.Entities.Auth;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult
                {
                    IsSuccessful = false,
                    Errors = new List<string> { "Datos inválidos." }
                });
            }

            var userResponse = await _userService.Register(userRegistration);

            if (userResponse is not null && !userResponse.IsSuccessful)
            {
                return BadRequest(userResponse);
            }

            return Ok(userResponse);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var loginResponse = await _userService.Login(userLogin);

            if (loginResponse is not null && !loginResponse.IsSuccessful)
            {
                return BadRequest(loginResponse);
            }

            return Ok(loginResponse);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string> { "Invalid parameters" },
                    IsSuccessful = false
                });

            var results = await _userService.VerifyAndGenerateTokenAsync(tokenRequest);

            if (results == null)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string> { "Invalid token" }
                });

            return Ok(results);
        }

    }
}