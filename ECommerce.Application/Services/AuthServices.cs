using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.RRModels.Auth;
using ECommerce.Domain.Entities;

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

        public async Task<string> Login(LoginRequest model)
        {
            var user=await authRepository.FirstOrDefaultAsync(user=>user.Email==model.Email);
            if(user is null)
            {
                return "Invalid Credentials";
            }
            var hashedPassword = appEncryption.HashPassword(model.Password, user.Salt);
            if (hashedPassword != user.Password)
            {
                return "Invalid Credentials";
            }
            var token = jWTrovider.GenerateToken(user);
            return token;

        }
    }
}
