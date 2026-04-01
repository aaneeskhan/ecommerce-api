
using ECommerce.Application;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure;
using ECommerce.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Api
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
            services.AddApplicationServices();
            services.AddInfrastructureServices();
            services.AddPersistenceServices(configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("{\"error\": \"You are not authorized to access this resource. Please login again.\"}");
                    }
                };

            });


            
                
                


            // 1) Client request
            // 2) validate
            // 3) valid    OR      not validated challege trigger
            // 4) string token converted into claimsPricipal
            //              1)  each claim will be conveted into Claims        new Claim(UserClaims.UserId, "aJSFGJSGFSJGFSJFGJSGFSHGDFGSHDF")),
            //     new Claim(UserClaims.Email,"sani@gmail.com"),
            //      new Claim(UserClaims.PhoneNo, "92834729873492734),
            //      new Claim(UserClaims.UserRole,"admin)

            // 2)  Claims Identity  
            // 3)  ClaimsPricipal = User
            // 5) Authorize
            // 6) Controller 


            return services;
        }
    }
}
