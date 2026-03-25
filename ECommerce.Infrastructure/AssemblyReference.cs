using ECommerce.Application.Abstraction.AppEncryption;
using ECommerce.Application.Abstraction.IJwtProvider;
using ECommerce.Infrastructure.Encryption;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class AssemblyReference
    {
          public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
          {
            
            services.AddScoped<IAppEncryption,AppEncryption>();
            services.AddScoped<IJWTProvider, ECommerce.Infrastructure.JWTProvider.JWTProvider>();
            return services;
          }
    }
}
