using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction
{
    public interface IExceptionService
    {
        Task<bool> HandleException(HttpContext httpContext, Exception exception, CancellationToken cancellationToken);
    }
}
