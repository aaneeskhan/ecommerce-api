using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Infrastructure.JWTProvider
{
    public class JWTProvider(IConfiguration configuration) : IJWTrovider
    {
        public string GenerateToken(User user)
        {
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(UserClaims.Id, user.Id.ToString()),
                    new Claim(UserClaims.Email, user.Email),
                    new Claim(UserClaims.PhoneNo, user.PhoneNo),
                    new Claim(UserClaims.UserRole,user.UserRole.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"],

                SigningCredentials = new SigningCredentials(

                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    SecurityAlgorithms.HmacSha256
                    )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
