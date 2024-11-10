using Api.Filters.ExceptionFilters;
using Core.IRepositories;
using Core.IServices;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Api.StartupExtensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HandleExceptionFilter));
            });
            services.AddSwaggerGen();

            services.AddSerilog();
            services.AddResponseCaching();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IProductTypesService, ProductTypesService>();

            services.AddScoped<IMeatTypesRepository, MeatTypesRepository>();
            services.AddScoped<IMeatTypesService, MeatTypesService>();

            services.AddScoped<IToppingsProductsRepository, ToppingsProductsRepository>();
            services.AddScoped<IToppingsProductsService, ToppingsProductsService>();

            services.AddScoped<IToppingsRepository, ToppingsRepository>();
            services.AddScoped<IToppingsService, ToppingsService>();

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrdersService, OrdersService>();

            return services;
        }
    }
}
