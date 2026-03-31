using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.JWTProvider
{
    public class UserClaims
    {
        public const string Id  = nameof(Id);
        public const string Email = nameof(Email);
        public const string PhoneNo=nameof(PhoneNo);
        public const string UserRole=nameof(UserRole);
    }
}
