using CarMaintenanceTracker.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CarMaintenanceTracker
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<CarMaintenanceTrackerDbContext>();
            services.AddScoped<DbContext, CarMaintenanceTrackerDbContext>();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab project API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
