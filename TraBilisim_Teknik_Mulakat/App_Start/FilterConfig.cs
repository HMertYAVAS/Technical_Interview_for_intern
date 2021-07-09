using System.Web;
using System.Web.Mvc;

namespace TraBilisim_Teknik_Mulakat
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
