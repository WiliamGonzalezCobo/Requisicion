using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web.Routing;

namespace G_H_WEB.Logica_Session
{
    public class CustAuthFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.QueryString.Count == 1 || filterContext.HttpContext.Request.QueryString.Count == 2) {
                if (filterContext.HttpContext.Request.QueryString.Keys[0] != "link_controler")
                {
                    if (filterContext.HttpContext.User.Identity.Name == "")
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "CUENTA", action = "VALIDAR" }));
                    }
                }
            }

            if (filterContext.HttpContext.Request.QueryString.Count == 0) {
                if (filterContext.HttpContext.Session["COD_ASPNETUSER_CONTROLLER"] == null)
                {
                    if (filterContext.HttpContext.User.Identity.Name == "")
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "CUENTA", action = "VALIDAR" }));
                    }
                }
                
            }
        }
    }
}