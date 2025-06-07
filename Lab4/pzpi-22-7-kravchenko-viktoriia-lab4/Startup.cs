using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;
using Swashbuckle.Application;
using System.Web.Http.Cors;
using Unity;



namespace AquaTrack
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Налаштування CORS
            app.UseCors(CorsOptions.AllowAll);
            var cors = new EnableCorsAttribute("http://localhost:3000", "*", "*"); // Дозволити всі домени, методи та заголовки


            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.EnableCors(cors);

            // Реєстрація компонентів Unity
            UnityConfig.RegisterComponents(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
            // Налаштування Swagger
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "AquaTrack API");
            }).EnableSwaggerUi();  // Додаємо Swagger UI
        }
    }
}
