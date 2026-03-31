
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
            services.AddPersistenceServices(configuration);
            services.AddInfrastructureServices();


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
