using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Application.Contracts.Persistance;
using PetStore.Persistance.Repositories;
using PetStore.Persistance;
using PetStore.Application.Contracts.Persistence;

namespace PetStore.Persistence
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PetStoreDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();



            return services;
        }
    }
}

