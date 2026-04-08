using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Abstraction.IServices
{
    public interface IUserService

    {
        Task<Result<IEnumerable<UserResponse>>> GetUsers();
        Task<Result<UserResponse>> GetUserById(Guid id);
        Task<Result<IEnumerable<UserResponse>>> GetUserByRole(string userRole);
        Task<Result<IEnumerable<UserResponse>>> GetUserByEmail(string email);
    }
}
