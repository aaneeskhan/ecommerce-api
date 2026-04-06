using ECommerce.Application.Abstraction.RRModels.Auth;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IService
{
    public interface IAuthService
    {
        Task<int> UserSignUp(SignUpRequest model);
        Task<IEnumerable<User>> GetUsers();
    }
}
