using System.Web;
using System.Web.Mvc;

namespace YunxiWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //  filters.Add(DependencyResolver.Current.GetService<UserBllFilter>());
        }
    }
}
