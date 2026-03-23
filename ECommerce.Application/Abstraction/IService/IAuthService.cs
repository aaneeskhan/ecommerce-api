using ECommerce.Application.RRModels.UserAddressCompact;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IService
{
    public interface IAuthService
    {
        Task<int> CustomerSignUp(UserAddressCompactRequest model);
        Task<int> EmployeeSignUp(UserAddressCompactRequest model);
        Task<int> Login(string userName, string password);
    }
}
