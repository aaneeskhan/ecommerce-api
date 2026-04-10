using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IContextService;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Infrastructure.Encryption;
using ECommerce.Infrastructure.JWTProvider;
using ECommerce.Infrastructure.StorageService.LocalStorageService;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class AssemblyReference
    {
          public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
          {
            services.AddScoped<IAppEncryption, AppEncryption>();
            services.AddScoped<IJWTrovider, JWTProvider.JWTProvider>();
            services.AddScoped<IContextService, ContextService.ContextService>();
            services.AddScoped<IStorageService, StorageService.LocalStorageService.StorageService>();
            return services;
          }
    }
}
