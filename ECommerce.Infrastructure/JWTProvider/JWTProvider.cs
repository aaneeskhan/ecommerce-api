using ECommerce.Application.Abstraction.IJWTProvider;
using ECommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Infrastructure.JWTProvider
{
    public class JWTProvider(IConfiguration configuration) : IJWTProvider
    {
        public string GenerateToken(Users users)
        {
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                new Claim(UserClaims.UserId,users.Id.ToString()),
                new Claim(UserClaims.Email,users.Email),
                new Claim(UserClaims.PhoneNo,users.PhoneNo.ToString()),
                new Claim(UserClaims.UserRole,users.UserRole.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(5),
                IssuedAt= DateTime.UtcNow,
                Audience = configuration["JWT:Audience"],
                Issuer = configuration["JWT:Issuer"],
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),SecurityAlgorithms.HmacSha256),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
