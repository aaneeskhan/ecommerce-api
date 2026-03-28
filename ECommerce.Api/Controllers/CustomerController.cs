using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("customer-dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("WELCOME CUSTOMER DASHBOARD");
        }
    }
}
