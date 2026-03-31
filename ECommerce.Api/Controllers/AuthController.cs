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

        public async Task<string> SignUp(SignUpRequest model)
        { 
            return await authServices.SignUp(model);
        }
    }
}
