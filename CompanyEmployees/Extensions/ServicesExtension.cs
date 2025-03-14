﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using LoggerService;
namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
        });

        public static void ConfigureCor(this IServiceCollection services)
        {
            services.Configure<CorsOptions>(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
