using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RelationshipApi.Helpers.Auth;
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
            // Utils
            services.AddScoped<IJwtUtils, JwtUtils>();

            // Services
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFamilyService, FamilyService>();

            // Repos
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductOptionRepository, ProductOptionRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();
        }
    }
}