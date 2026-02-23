using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            return services;
        }
    }
}
