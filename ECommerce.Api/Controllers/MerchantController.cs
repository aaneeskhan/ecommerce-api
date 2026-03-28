using ECommerce.Infrastructure.JWTProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Merchant,Customer")]
    public class MerchantController : ControllerBase
    {
        [HttpGet("merchant-dashboard")]
        public IActionResult AdminDashboard()
        {
            return Ok("WELCOME MERCHANT DASHBOARD");
        }
    }
}
