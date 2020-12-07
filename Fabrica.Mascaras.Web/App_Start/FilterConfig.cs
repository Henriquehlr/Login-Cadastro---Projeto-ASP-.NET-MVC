using Fabrica.Mascaras.Web.Filtros;
using System.Web;
using System.Web.Mvc;

namespace Fabrica.Mascaras.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());            
            filters.Add(new LogActionFilter());
        }
    }
}
