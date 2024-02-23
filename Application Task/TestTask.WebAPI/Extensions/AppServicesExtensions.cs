using TestTask.Application.Data;
using TestTask.Application.Handlers.Commands;
using TestTask.Domain;

namespace TestTask.WebApi.Extensions
{
    public static class AppServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
