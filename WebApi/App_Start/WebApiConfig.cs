using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                
                 name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            
             
            );
            config.Routes.MapHttpRoute(
           name: "DefaultApii",
           routeTemplate: "api/{controller}/{Actions}/{pass}",
           defaults: new { pass = RouteParameter.Optional }
       );
            config.Routes.MapHttpRoute(
         name: "DefaultAp",
         routeTemplate: "api/{controller}/{Action}/{id}",
         defaults: new { id = RouteParameter.Optional }
     );

        }
    }
}
