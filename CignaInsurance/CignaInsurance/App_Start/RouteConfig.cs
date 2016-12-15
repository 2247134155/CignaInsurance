using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CignaInsurance
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "HomePage",
                url: "",
                defaults: new { controller = "Homepage", action = "Index",  id = UrlParameter.Optional }
                //Chris Got It
            );
            routes.MapRoute(
                name: "Search",
                url: "Doctor/FindADoctor/Search",
                defaults: new { controller = "Doctor", action = "Search", id = UrlParameter.Optional }
                //Chris Got It
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //Chris Got It
            );
        }
    }
}
