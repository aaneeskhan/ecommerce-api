using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Infrastructure.Encryption;
using ECommerce.Infrastructure.JWTProvider;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class AssemblyReference
    {
          public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
          {
            services.AddScoped<IAppEncryption, AppEncryption>();
            services.AddScoped<IJWTrovider, JWTProvider.JWTProvider>();
            return services;
          }
    }
}
