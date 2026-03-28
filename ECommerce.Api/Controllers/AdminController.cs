using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {

        [HttpGet("admin-dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("WELCOME ADMIN DASHBOARD");
        }
    }
}
