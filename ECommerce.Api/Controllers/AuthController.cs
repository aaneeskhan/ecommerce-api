using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.RRModels.UserAddressCompact;
using ECommerce.Application.RRModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (IAuthService authService): ControllerBase
    {
        [HttpPost("customer")]
        public async Task<IActionResult> CustomerSignUp(CustomerAddressCompactRequest model)
        {
            int returnValue=await authService.CustomerSignUp(model);
            return returnValue>0?Ok("Customer Added Succesfully"):BadRequest("Failed to Add Customer");
        }
        [HttpPost("employee")]
        public async Task<IActionResult> EmployeeSignUp(EmployeeAddressCompactRequest model)
        {
            int returnValue = await authService.EmployeeSignUp(model);
            return returnValue > 0 ? Ok("Employee Added Succesfully") : BadRequest("Failed to Add Employee");
        }
    }
}
