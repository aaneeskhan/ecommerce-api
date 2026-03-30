using ECommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
          
            return services;
        }
    }
}
