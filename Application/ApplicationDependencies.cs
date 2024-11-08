using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Feature.User.Mapping;


namespace Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(UserProfile));

            services.AddDistributedMemoryCache();

            return services;
        }
    }
}
