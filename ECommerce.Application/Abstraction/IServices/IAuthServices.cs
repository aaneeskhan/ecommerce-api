using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.RRModels.Auth;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface IAuthServices
    {
        Task<string> SignUp(SignUpRequest model);
    }
}
