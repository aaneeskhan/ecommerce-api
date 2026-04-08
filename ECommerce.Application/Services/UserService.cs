using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace ECommerce.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
         public async Task<Result<IEnumerable<UserResponse>>> GetUsers()
        {
           var res= (await userRepository.GetAllAsync()).Select(x=> new UserResponse
            {
                Email=x.Email,
                PhoneNo=x.PhoneNo,
                UserRole=x.UserRole,
                UserStatus=x.UserStatus
                
            });
          if( res  is null || !res.Any() || res.Count() == 0)
            {
            return Result<IEnumerable<UserResponse>>.Failure("Users Not found", StatusCodes.Status404NotFound);
            }
            return Result<IEnumerable<UserResponse>>.Success(res);
        }
        public async Task<Result<IEnumerable<UserResponse>>> GetUserByEmail(string email)
        {
            var users = await userRepository.FindByAsync(x => x.Email.StartsWith(email));
            var userList=users.Select(x => new UserResponse
            {
                Email=x.Email,
                PhoneNo=x.PhoneNo,
                UserRole= x.UserRole,
                UserStatus=x.UserStatus
            }).ToList();
            if (userList is null || userList.Count == 0)
            {
                return Result<IEnumerable<UserResponse>>.Failure("No match found", StatusCodes.Status404NotFound);
            }
            return Result<IEnumerable<UserResponse>>.Success(userList);
        }

        public async Task<Result<UserResponse>> GetUserById(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);
            UserResponse userResponse = new UserResponse
            {
                Email=user.Email,   
                PhoneNo = user.PhoneNo,
                UserRole = user.UserRole,
                UserStatus = user.UserStatus
            };
            if (user is null)
            {
                return Result<UserResponse>.Failure("No match found", StatusCodes.Status404NotFound);
            }
            return Result<UserResponse>.Success(userResponse);
        }

        public async Task<Result<IEnumerable<UserResponse>>> GetUserByRole(string userRole)
        {
            UserRole role = Enum.Parse<UserRole>(userRole,true);
            var users = await userRepository.FindByAsync(x => x.UserRole == role);
            var userList=users.Select(x => new UserResponse
            {
                Email=x.Email,
                PhoneNo=x.PhoneNo,
                UserRole=role,
                UserStatus=x.UserStatus
            }).ToList();
            if (userList is null || userList.Count == 0)
            {
                return Result<IEnumerable<UserResponse>>.Failure("No match found", StatusCodes.Status404NotFound);
            }
            return Result<IEnumerable<UserResponse>>.Success(userList);
        }
    }
}
