using ECommerce.Application.Abstraction.IIdentity;
using ECommerce.Infrastructure.JWTProvider;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ECommerce.Infrastructure.Identity
{
    internal class ContextService(IHttpContextAccessor contextAccessor) : IContextService
    {
        public string GetClientUrl()
        {
            var clientAddress=  contextAccessor.HttpContext.Request.Headers["Referer"];
            return clientAddress;
        }

        public string GetCurrentUrl()
        {
            var protocol = contextAccessor.HttpContext.Request.Protocol;
            var server = contextAccessor.HttpContext.Request.Host;
            var path = contextAccessor.HttpContext.Request.Path;
            return $@"{protocol}://{server}/{path}";
        }

        public string GetPhoneNo()
        {
            var phoneNo = contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == UserClaims.PhoneNo)!.Value;
            return phoneNo ?? string.Empty;
        }

        public Guid GetUserId()
        {
           var userId=  contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == UserClaims.UserId)!.Value;
           if(Guid.TryParse(userId, out Guid uid))
            {
                return uid; 
            }
           return Guid.Empty;
        }

        public string GetUserName()
        {
            //var email = contextAccessor.HttpContext?.User?.Identity?.Name;
            var email = contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == UserClaims.Email)!.Value;
            return email ?? string.Empty;
        }

        public string GetUserRole()
        {
            var role = contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == UserClaims.Role)!.Value;
            return role ?? string.Empty;
        }
    }
}
