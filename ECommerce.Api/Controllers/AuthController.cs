using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthServices authServices) : ControllerBase
    {
        [HttpPost("signup")]

        public async Task<IActionResult> SignUp(SignUpRequest model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await authServices.SignUp(model));

            }
            return BadRequest("Something went wrong");
            
        }

        [HttpGet("login")]

        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await authServices.Login(model));

            }
            return BadRequest("Something went wrong");

        }

    }
}
