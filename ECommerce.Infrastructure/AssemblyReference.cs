using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IContextService;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Application.Abstraction.IStorageService;
using ECommerce.Infrastructure.Encryption;
using ECommerce.Infrastructure.JWTProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class AssemblyReference
    {
          public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,string webRootPath,bool isDevelopment,IConfiguration configuration)
          {
            services.AddScoped<IAppEncryption, AppEncryption>();
            services.AddScoped<IJWTrovider, JWTProvider.JWTProvider>();
            services.AddScoped<IContextService, ContextService.ContextService>();
            services.AddSingleton<IStorageService>(new StorageService.LocalStorageService(webRootPath));
            return services;
          }
    }
}
