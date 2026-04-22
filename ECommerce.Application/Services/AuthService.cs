using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IContextService;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Abstraction.IUnitOfWork;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Application.RRModels.Users;
using ECommerce.Application.Utils.Result;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace ECommerce.Application.Services
{
    public class AuthService(IAuthRepository authRepository,IAppEncryption appEncryption,IJWTrovider jWTrovider,IContextService contextService,IUnitOfWork unitOfWork) : IAuthServices
    {
        

        public async Task<Result<string>> SignUp(SignUpRequest model)
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
             await authRepository.AddAsync(user);
            var res= await unitOfWork.SaveChangeAsync();
            if (res>0)
            {
                return Result<string>.Success("User added successfully");
            }
            return Result<string>.Failure("Something went wrong", StatusCodes.Status400BadRequest);
        }

        public async Task<Result<string>> Login(LoginRequest model)
        {
            var user=await authRepository.FirstOrDefaultAsync(user=>user.Email==model.Email);
            if(user is null)
            {
                return Result<string>.Failure("Invalid Credentials", StatusCodes.Status400BadRequest);
            }

            if(user.UserStatus!= UserStatus.Active)
            {
                return Result<string>.Failure("User is not active", StatusCodes.Status403Forbidden);
            }
            var hashedPassword = appEncryption.HashPassword(model.Password, user.Salt);
            if (hashedPassword != user.Password)
            {
               return Result<string>.Failure("Invalid Credentials", StatusCodes.Status400BadRequest);
            }
            var token = jWTrovider.GenerateToken(user);
          return Result<string>.Success(token);
        }

      

        public async Task<Result<string>> ChangePassword(ChangePassword model)
        {
            var userId=contextService.GetId();
            var user=await authRepository.GetByIdAsync(userId);
            if(user is null)
            {
                return  Result<string>.Failure("User not found", StatusCodes.Status404NotFound);
            }
           
            var oldPassword = appEncryption.HashPassword(model.OldPassword, user.Salt);

            if(oldPassword!=user.Password)
            {
                return Result<string>.Failure("Wrong Password", StatusCodes.Status409Conflict);
            }

            var salt = appEncryption.GenerateSalt();
            var newPassword=appEncryption.HashPassword(model.NewPassword, salt);
            user.Salt = salt;
            user.Password = newPassword;
            await authRepository.UpdateAsync(user);
            var returnValue= await unitOfWork.SaveChangeAsync();
            if (returnValue > 0)
            {
                return Result<string>.Success("password changed successfully");
            }
            return Result<string>.Failure("Something went wrong", StatusCodes.Status500InternalServerError);

        }
    }
}
