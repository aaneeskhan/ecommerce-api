using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public enum UserStatus
    {
        Active=1,
        InActive=2,
        Blocked=3
    }
    public enum UserRole
    {
       Admin=1,
       Customer= 2
    }
}
