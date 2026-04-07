using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Controllers
{
    public class MyResult : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.WriteAsync("");
            base.ExecuteResult(context);
        }
    }

    public class MyResult1 : IResult
    {
        public Task ExecuteAsync(HttpContext httpContext)
        {
            return httpContext.Response.WriteAsync("");
        }
    }
}
