using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IJwtProvider
{
    public interface IJWTProvider
    {
        public string GenerateToken(Users user);
    }
}
