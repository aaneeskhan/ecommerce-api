using ECommerce.Application.Abstraction.IAppEncryption;
using ECommerce.Application.Abstraction.IJWTProvider;
using ECommerce.Infrastructure.Encryption;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure
{
    public static class AssemblyReference
    {
          public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
          {
            services.AddScoped<IJWTProvider, ECommerce.Infrastructure.JWTProvider.JWTProvider>();
            services.AddScoped<IAppEncryption,AppEncryption>();
         
            return services;
          }
    }
}
