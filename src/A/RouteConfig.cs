using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace A
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}