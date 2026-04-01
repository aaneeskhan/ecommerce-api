using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.JWTProvider
{
    public struct UserClaims
    {
        public const string UserId=nameof(UserId);
        public const string Email=nameof(Email);
        public const string PhoneNo=nameof(PhoneNo);
        public const string UserRole=nameof(UserRole);
    }
}
