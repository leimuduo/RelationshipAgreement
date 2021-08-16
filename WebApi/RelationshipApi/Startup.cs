using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using RelationshipApi.Helpers;
using RelationshipApi.IoC;
using RelationshipApi.Models.Entities;

namespace RelationshipApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var temp = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNET_ENV")}.json", true, true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Turn on cache
            services.AddMemoryCache();

            // IoC
            services.RegisterServices(Configuration);

            // Add AutoMapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Startup)));

            // DB setup
            services.AddDbContext<ProductsContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // Logging
            services.AddLogging(log =>
            {
                log.ClearProviders();
                log.SetMinimumLevel(LogLevel.Trace);
                log.AddNLog(Configuration.GetSection("Logging"));
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RelationshipApi", Version = "v1"});
            });

            // allow CORS
            services.AddCors(o => o.AddPolicy("AllowOrigin",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RelationshipApi v1"));
            // }

            // Register global api error handling
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}