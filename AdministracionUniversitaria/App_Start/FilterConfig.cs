using System.Web;
using System.Web.Mvc;

namespace AdministracionUniversitaria
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
