using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fansoft.Store.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //habilita a configuração de rotas por atributo
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Editar",
                url: "Produtos/Edit/{id}",
                defaults: new { controller = "Produtos", action = "AddEdit" }
            );

            routes.MapRoute(
                name: "Adicionar",
                url: "Produtos/Adicionar",
                defaults: new { controller = "Produtos", action = "AddEdit" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
