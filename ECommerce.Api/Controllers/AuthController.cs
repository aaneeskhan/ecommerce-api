using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.Abstraction.RRModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("signup")]
        public async Task<IActionResult> UserSignUp(SignUpRequest model)
        {
            var user = await authService.UserSignUp(model);
            if (user > 0)
            {
                return Ok("User Created successfull");
            }
            else
                return BadRequest("There is some issue please try after some time");
        }
    }
}
