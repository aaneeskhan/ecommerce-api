using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IContextService;
using ECommerce.Infrastructure.JWTProvider;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Infrastructure.ContextService
{
    public class ContextService(IHttpContextAccessor context) : IContextService
    {
        public string GetClientURI()
        {
             context.HttpContext.Request.Headers.TryGetValue("Referer",out var referer);
            return referer;
        }

        public string GetCurrentURI()
        {
            return context.HttpContext.Request.Path.ToString();
        }

        public string GetEmail()
        {
           return context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == UserClaims.Email)!.Value;
        }

        public string GetPhoneNo()
        {
            return context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == UserClaims.PhoneNo)!.Value;
        }

        public Guid GetId()
        {
            return Guid.Parse( context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == UserClaims.Id)!.Value);
        }

        public string GetUserRole()
        {
            return context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == UserClaims.UserRole)!.Value;
        }
    }
}
