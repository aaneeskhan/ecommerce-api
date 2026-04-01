using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IJWTProvider;
using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Application.Abstraction.IService;
using ECommerce.Application.Abstraction.RRModels.Auth;
using ECommerce.Domain;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Service
{
    public class AuthService(IAppEncryption appEncryption,IAuthRepository authRepository, IJWTProvider jwtProvider) : IAuthService
    {
        public async Task<int> UserSignUp(SignUpRequest model)
        {
            var salt = appEncryption.GenerateSalt();
            var hashedPassword = appEncryption.HashPassword(model.Password, salt);

            User users = new User()
            {
                Email = model.Email,
                PhoneNo = model.PhoneNo,
                Password = hashedPassword,
                ConfirmationCode = "",
                UserRole = model.UserRole,
                Salt = salt,
            };

            int returnValue = await authRepository.AddAsync(users);
            return returnValue;
        }

       
    }
}
