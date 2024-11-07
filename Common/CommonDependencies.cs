using Common.Interface;
using Common.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class CommonDependencies
    {
        public static IServiceCollection AddCommonDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICommon), typeof(CommonService));
            return services;
        }
    }
}
