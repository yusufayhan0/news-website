using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
               name: "Index",
               url: "",
               defaults: new { controller = "Home", action = "Index" }
               );

            //routes.MapRoute(
            //   name: "hakkimizda",
            //   url: "Hakkimizda",
            //   defaults: new { controller = "Home", action = "hakkimizda" }
            //   );

            //routes.MapRoute(
            //   name: "iletisim",
            //   url: "Iletisim",
            //   defaults: new { controller = "Home", action = "iletisim" }
            //   );

            //routes.MapRoute(
            //   name: "haber_detay",
            //   url: "haberler/{title}/{id}",
            //   defaults: new { controller = "Home", action = "haber_detay", id = UrlParameter.Optional,title= UrlParameter.Optional}
            //   );

            //routes.MapRoute(
            //   name: "kategori_detay",
            //   url: "Kategori/{title}/{id}",
            //   defaults: new { controller = "Home", action = "kategori_detay",title=UrlParameter.Optional , id = UrlParameter.Optional }
            //   );

            //routes.MapRoute(
            //   name: "giris",
            //   url: "Admin",
            //   defaults: new { controller = "Home", action = "giris"}
            //   );

            //routes.MapRoute(
            //  name: "aramaYap",
            //  url: "arama",
            //  defaults: new { controller = "Home", action = "aramaYap"}
            //  );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }

    }
}
