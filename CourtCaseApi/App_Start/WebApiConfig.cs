using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Http.Cors;

namespace CourtCaseApi
{
    public static class WebApiConfig
    {
       // [EnableCors("*", "*", "*")]
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
           var cors = new EnableCorsAttribute("http://localhost:1619", "*", "*");
              config.EnableCors(cors);
              // config.GetCorsPolicyProviderFactory();
//                [EnableCors("*", "*", "*")]
        // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           /* EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:1619", "*", "*");
            config.EnableCors(cors);*/
        }
    }
}
