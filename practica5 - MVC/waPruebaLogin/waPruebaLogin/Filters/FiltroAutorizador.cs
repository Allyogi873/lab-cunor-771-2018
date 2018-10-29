using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using waPruebaLogin.Models;
namespace waPruebaLogin.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class FiltroAutorizador : AuthorizeAttribute
    {
        ctxPrueba db = new ctxPrueba();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string username = "";
            string controllerName = filterContext.RouteData.Values["Controller"].ToString().ToLower();
            string actionName = filterContext.RouteData.Values["Action"].ToString().ToLower();

            if (filterContext == null)
                HandleUnauthorizedRequest(filterContext);

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                AspNetUsers usr = db.AspNetUsers.Where(a => a.UserName == username).FirstOrDefault();

                if (usr.IdRol != "1")
                {
                    if (controllerName == "usuarios")
                    {
                        HandleUnauthorizedRequest(filterContext);
                    }
                }
            }
            else {
                if (controllerName != "account" && actionName != "login") {
                    filterContext.Result =
                           new RedirectToRouteResult
                               (
                                    new RouteValueDictionary{
                                                { "controller", "Account" },
                                                { "action", "Login" }
                               });
                }
                
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =
           new RedirectToRouteResult
               (
                    new RouteValueDictionary{
                                { "controller", "Home" },
                                { "action", "Index" }
               });

        }
    }
}