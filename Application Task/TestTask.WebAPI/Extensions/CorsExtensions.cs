namespace TestTask.WebApi.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsExtension(
            this IServiceCollection services,
            ConfigurationManager configuration
            )
        {
            services.AddCors(options =>
            {
                options.AddPolicy(configuration.GetSection("CorsSettings:PolicyName").Get<string>(),
                    policy =>
                    {
                         policy.WithOrigins(configuration.GetSection("CorsSettings:AllowedOrigins").Get<string[]>())
                               .WithHeaders(configuration.GetSection("CorsSettings:AllowedHeaders").Get<string[]>())
                               .WithMethods(configuration.GetSection("CorsSettings:AllowedMethods").Get<string[]>());
                    });
            });

            return services;
        }
    }
}
