using System.Web;
using System.Web.Mvc;

namespace WebSite_Semana11_Lunes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
