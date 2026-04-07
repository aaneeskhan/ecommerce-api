using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services
{
    public class AuthServices(IAuthRepository authRepository,IAppEncryption appEncryption,IJWTrovider jWTrovider) : IAuthServices
    {
        

        public async Task<string> SignUp(SignUpRequest model)
        {
            var salt = appEncryption.GenerateSalt();
            var hashedPassword=appEncryption.HashPassword(model.Password, salt);

            var user = new User() 
            { 
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                UserRole=model.UserRole,
                Salt=salt,
                Password=hashedPassword
            };
            var res= await authRepository.AddAsync(user);
            if(res>0)
            {
                return "User Added successfully";
            }
            return "Something went wrong";
        }

        public async Task<Result<string>> Login(LoginRequest model)
        {
            var user=await authRepository.FirstOrDefaultAsync(user=>user.Email==model.Email);
            if(user is null)
            {
                return Result<string>.Failure("Invalid Credentials", StatusCodes.Status400BadRequest);
            }
            var hashedPassword = appEncryption.HashPassword(model.Password, user.Salt);
            if (hashedPassword != user.Password)
            {
               return Result<string>.Failure("Invalid Credentials", StatusCodes.Status400BadRequest);
            }
            var token = jWTrovider.GenerateToken(user);
          return Result<string>.Success(token);
        }

       
    }
}
