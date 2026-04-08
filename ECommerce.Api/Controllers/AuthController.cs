using Azure;
using ECommerce.Api.CustomExtensions;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Domain;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IResult> SignUp(SignUpRequest model) => this.ApiResponse(await authServices.SignUp(model));
        

        [HttpPost("login")]

        public async Task<IResult> Login(LoginRequest model) =>   this.ApiResponse(await authServices.Login(model));


        [HttpPost("change-password")]
        [Authorize]
        public async Task<IResult> ChangePassword(ChangePassword model)=> this.ApiResponse(await authServices.ChangePassword(model));
            
        
    }
}
