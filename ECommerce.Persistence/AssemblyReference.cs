using ECommerce.Application.Abstraction.IRepository;
using ECommerce.Persistence.Data;
using ECommerce.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>(X => X.UseSqlServer(configuration.GetConnectionString("ECommerceConnection")));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAddressRepository, AddresssRepository>();
            return services;
        }
    }
}
