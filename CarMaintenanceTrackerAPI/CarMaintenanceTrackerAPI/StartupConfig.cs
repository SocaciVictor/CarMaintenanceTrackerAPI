using CarMaintenanceTracker.Database.Context;
using CarMaintenanceTrackerAPI.Core.Services;
using CarMaintenanceTrackerAPI.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CarMaintenanceTracker
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<CarsServices>();
            services.AddScoped<UsersServices>();
            //services.AddScoped<AuthServices>();
            //services.AddScoped<ServicesCentersServices>();
            //services.AddScoped<MaintenancesRecordsServices>();

        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<CarMaintenanceTrackerDbContext>();
            services.AddScoped<DbContext, CarMaintenanceTrackerDbContext>();

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IServiceCenterRespository, ServiceCenterRepository>();
            //services.AddScoped<IMaintenanceRecordRepository, MaintenanceRecordRepository>();
            //services.AddScoped<ICarServiceCenter, CarServiceCenterRepository>();

        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Car Maintenance Tracker", Version = "v1" });
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
