using Azure;
using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    // http://localhost:5032/api/auth/signup
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

        [HttpPost("login")]

        public async Task<IResult> Login(LoginRequest model) =>   this.ApiResponse(await authServices.Login(model));


        [HttpPost("change-password")]

        public async Task<IResult> ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                return this.ApiResponse(await )
            }
        }
    }
}
