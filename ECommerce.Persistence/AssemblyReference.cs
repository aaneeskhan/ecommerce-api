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
          services.AddScoped<IAuthRepository,AuthRepository>();
          services.AddScoped<IUserRepository,UserRepository>();
          services.AddScoped<IAdddressRepository,AddressRepository>();
          services.AddScoped<ICategoryRepository,CategoryRepository>();
          services.AddScoped<IProductRepository,ProductRepository>();
          services.AddScoped<IProductDetailsRepository,ProductDetailsRepository>();
            services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(configuration.GetConnectionString("ECommerceDbContext")));
            return services;
        }
    }
}
