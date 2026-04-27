using ECommerce.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Exception
{
    public class ExceptionService(ILogger<ExceptionService> logger) : IExceptionService
    {
        public Task<bool> HandleException(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            StringBuilder sb = new StringBuilder($@"Nameeeeeeeeeeeeeeeeeee :{exception.GetType()} {Environment.NewLine} {Environment.NewLine}");
            sb.Append($@"Message :{exception.Message} {Environment.NewLine} {Environment.NewLine}");
            sb.Append($@"StackTrace :{exception.StackTrace} {Environment.NewLine} {Environment.NewLine}");
            sb.Append($@"DateTome :{DateTime.Now}");
            logger.LogError(message: sb.ToString());


            throw new NotImplementedException();
        }
    }
}
