using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("");
            //ActionResult result = new OkObjectResult("Welcome to the E-Commerce API!");
            //IActionResult res= new BadRequestObjectResult("Bad Request");
            //NotFoundObjectResult obj = new NotFoundObjectResult("user not found");
            //ActionResult oo = new ContentResult();
        
           // Content("kjsdhfjksdh","application/json")
           
            
            //OkResult okResult = new OkResult();
            //HttpStatusCode
            //return Ok("Welcome to the E-Commerce API!");
        }
    }
}
