using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            return services;
        }
    }
}
