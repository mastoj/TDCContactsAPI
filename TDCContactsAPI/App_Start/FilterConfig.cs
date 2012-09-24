using System.Web;
using System.Web.Mvc;
using TDCContactsAPI.Filters;

namespace TDCContactsAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}