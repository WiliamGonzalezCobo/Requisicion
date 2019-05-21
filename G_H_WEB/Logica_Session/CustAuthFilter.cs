
using System.Web.Mvc;
using System.Web.Routing;

namespace G_H_WEB.Logica_Session
{
    public class CustAuthFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.Name == "") {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "CUENTA", action = "VALIDAR" }));
            }else if (filterContext.HttpContext.Session["objetoListas"] == null) {
                 filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "REQUISICION", action = "Index" }));
            }
        }
    }
}