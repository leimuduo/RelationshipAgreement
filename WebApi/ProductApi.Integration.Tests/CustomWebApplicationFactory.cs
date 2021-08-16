using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProductApi.Models.Entities;
using ProductsApi.Integration.Tests;

namespace ProductApi.Integration.Tests
{
    public class CustomWebApplicationFactory<TStartup> :
        WebApplicationFactory<TStartup> where TStartup : class
    {
        // protected override void ConfigureWebHost(CreateHostBuilder builder)
        // {
        //     builder.ConfigureServices(services =>
        //     {
        //         // Create a new service provider.
        //         var serviceProvider = new ServiceCollection()
        //             .AddEntityFrameworkInMemoryDatabase()
        //             .BuildServiceProvider();
        //
        //         // Add a database context (ApplicationDbContext) using an in-memory 
        //         // database for testing.
        //         services.AddDbContext<ProductsContext>(options =>
        //         {
        //             options.UseInMemoryDatabase("InMemoryDbForTesting");
        //             options.UseInternalServiceProvider(serviceProvider);
        //         });
        //     });
        // }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<ProductsContext>));
                services.Remove(descriptor);
                services.AddDbContext<ProductsContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ProductsContext>();
                var logger = scopedServices
                    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                db.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbForTests(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        "database with test messages. Error: {Message}", ex.Message);
                }
            });
        }
        //
        //
        // public static IHostBuilder ConfigureWebHost(string[] args)
        // {
        //     return Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
        //         .ConfigureServices(services =>
        //         {
        //             // Create a new service provider.
        //             var serviceProvider = new ServiceCollection()
        //                 .AddEntityFrameworkInMemoryDatabase()
        //                 .BuildServiceProvider();
        //
        //             // Add a database context (ApplicationDbContext) using an in-memory 
        //             // database for testing.
        //             services.AddDbContext<ProductsContext>(options =>
        //             {
        //                 options.UseInMemoryDatabase("InMemoryDbForTesting");
        //                 options.UseInternalServiceProvider(serviceProvider);
        //             });
        //         });
        // }
    }
}