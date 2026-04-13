using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Application.Abstraction.IContextService;
using ECommerce.Application.Abstraction.IServices;
using ECommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthServices,AuthService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAddressService,AddressService>();
            return services;
        }
    }
}
