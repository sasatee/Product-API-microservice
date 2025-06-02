using Core.ServiceContracts;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Core
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            
            services.AddTransient<IProductService, ProductService>();
            return services;
        
        }
    }
}
