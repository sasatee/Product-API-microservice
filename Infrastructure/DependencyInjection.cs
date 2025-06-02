using Core.IRepository;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace Infrastructure
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
      

            return services;
        
        }
    }
}
