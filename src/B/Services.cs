using Microsoft.Extensions.DependencyInjection;

namespace B
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            return services;
        }
    }
}