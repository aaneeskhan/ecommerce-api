using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface IAuthServices
    {
        Task<Result<string>> SignUp(SignUpRequest model);
        Task<Result<string>> Login(LoginRequest model);
        Task<Result<string>> ChangePassword(ChangePassword model);
        
    }
}
