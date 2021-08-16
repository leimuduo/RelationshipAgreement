using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RelationshipApi.Repositories;
using RelationshipApi.Repositories.Implementation;
using RelationshipApi.Repositories.Interfaces;
using RelationshipApi.Services.Implementation;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.IoC
{
    public static class DiRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductOptionService, ProductOptionService>();

            // Repos
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductOptionRepository, ProductOptionRepository>();
        }
    }
}