using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstraction.IJwtProvider
{
    public interface IJWTrovider
    {
        string GenerateToken(User user);
    }
}
