using System;
using B;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace A
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddServices().Configure<ForwardedHeadersOptions>(options => { });
            return services.BuildServiceProvider();
        }

        public void ConfigureDevelopment(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Information);

            app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
            {
                SourceCodeLineCount = 25
            });

            Configure(app);
        }

        public void ConfigureStaging(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler("/Home/Error");

            Configure(app);
        }

        public void ConfigureProduction(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler("/Home/Error");

            Configure(app);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();

            app.UseMvc(RouteConfig.RegisterRoutes);
        }
    }
}