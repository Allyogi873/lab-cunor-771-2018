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

            // Si ya ha iniciado sesión el usuario
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                AspNetUsers usr = db.AspNetUsers.Where(a => a.UserName == username).FirstOrDefault();

                permisos permiso = (from m in db.permisos
                                    where m.controlador == controllerName && m.vista == actionName && m.IdRol == usr.IdRol
                                    select m).FirstOrDefault();

                if (permiso == null)
                {
                    if (controllerName != "home" && controllerName != "account")
                    {
                        HandleUnauthorizedRequest(filterContext);
                    }
                }
                else {
                    if (controllerName != "home")
                    {
                        if (permiso.estado == 0) {
                            HandleUnauthorizedRequest(filterContext);
                        }
                    }
                }



                //if (usr.IdRol != "1")
                //{
                //    if (controllerName == "usuarios" || controllerName == "secciones")
                //    {
                //        HandleUnauthorizedRequest(filterContext);
                //    }
                //}
            }
            else {
                if (controllerName != "account") {
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