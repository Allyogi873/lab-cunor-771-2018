using System.Web;
using System.Web.Mvc;
using waPruebaLogin.Filters;

namespace waPruebaLogin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new FiltroAutorizador());
        }
    }
}
