using ECommerce.Application.RRModels.UserAddressCompact;
using ECommerce.Application.RRModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Abstraction.IService
{
    public interface IAuthService
    {
        Task<int> CustomerSignUp(CustomerAddressCompactRequest model);
        Task<int> EmployeeSignUp(EmployeeAddressCompactRequest model);
        Task<int> Login(string userName, string password);
    }
}
