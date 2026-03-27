using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.RRModels.Login;
using ECommerce.Application.RRModels.UserAddressCompact;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Encryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService): ControllerBase
    {

      

        //Add Customer
        [HttpPost("customer")]
        public async Task<IActionResult> CustomerSignUp(UserAddressCompactRequest model)
        {
            int returnValue=await authService.CustomerSignUp(model);
            return returnValue>0?Ok("Customer Added Succesfully"):BadRequest("Failed to Add Customer");
        }


        //Add Employee
        [HttpPost("employee")]
        public async Task<IActionResult> EmployeeSignUp(UserAddressCompactRequest model)
        {
            int returnValue = await authService.EmployeeSignUp(model);
            return returnValue > 0 ? Ok("Employee Added Succesfully") : BadRequest("Failed to Add Employee");
        }


        //Login
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserLogInRequest  model)
        {
        
            //List<Claim> claims = new List<Claim>()
            //{
            //     new Claim("email","samia@gmail.com")
            //};
            //ClaimsIdentity identity = new ClaimsIdentity(claims,"Bearer");
            //ClaimsPrincipal User=new ClaimsPrincipal(identity);
            var token= await authService.Login(model);
            if (token == "error")
            {
                return NotFound("Incorrect UserName Or Password");
            }
            return Ok(token);
        }
       










    }
}
