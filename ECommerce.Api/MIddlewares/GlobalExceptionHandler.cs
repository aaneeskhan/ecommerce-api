using ECommerce.Application.Abstraction;
using ECommerce.Infrastructure.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.MIddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IExceptionService exceptionService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problem = new ProblemDetails
            {
                    Title = exception.Message,
                    Detail = exception.StackTrace,
                    Status = StatusCodes.Status500InternalServerError
            };

        
        

            await exceptionService.HandleException(httpContext, exception, cancellationToken);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";
            await  httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }
    }
}
