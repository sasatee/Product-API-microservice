using Core.RepositoryContracts;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using Core.Validators;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            string connectionStringTemplate =
                configuration.GetConnectionString("SQLServerConnection1")!;

           string connectionString = connectionStringTemplate.Replace("$MSSQL_HOST", Environment.GetEnvironmentVariable("MSSQL_HOST"))
                .Replace("$MSSQL_PASSWORD", Environment.GetEnvironmentVariable("MSSQL_PASSWORD"));
            //Add sql server
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(connectionString));
            });

            services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

            return services;
        }
    }
}
