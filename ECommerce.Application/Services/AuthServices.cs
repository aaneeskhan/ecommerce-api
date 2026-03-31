using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services
{
    public class AuthServices(IAuthRepository authRepository,IAppEncryption appEncryption) : IAuthServices
    {
        public async Task<string> SignUp(SignUpRequest model)
        {
            if(model.Password!=model.ConfirmPassword)
            {
                return  "Password mismatched";
            }
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
    }
}
