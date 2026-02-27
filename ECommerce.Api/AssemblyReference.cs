
using ECommerce.Application;
using ECommerce.Persistence;


namespace ECommerce.Api
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddApplicationServices();
            services.AddPersistenceServices(configuration);
            return services;
        }
    }
}
