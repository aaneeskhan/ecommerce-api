using ECommerce.Api.CustomExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
  
    public class HomeController(IWebHostEnvironment env) : ControllerBase
    {
        public IActionResult Get()
        {
             var path = env.WebRootPath;
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
