using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IIdentity
{
    public interface IContextService
    {
        // UserId
        // Email
        // PhoneNo
        // UserRole

        public Guid GetUserId();

        public string GetUserName();

        public string GetPhoneNo();

        public string GetUserRole();

        public string GetCurrentUrl();

        public string GetClientUrl();
    }
}
