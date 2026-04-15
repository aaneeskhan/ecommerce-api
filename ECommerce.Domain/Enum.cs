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
       Customer= 2,
       Merchant=3,
    }

    public enum Units
    {
        Pieces=1,

        Gram=2,

        KG=3,

        Litre=4,

        Dozen=5,

        Meter=6,
    }

    public enum AppModule
    {
        User = 1,

        Product = 2,
    }
}
