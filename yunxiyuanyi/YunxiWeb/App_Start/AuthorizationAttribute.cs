using Entity.LogicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YunxiWeb
{
    /// <summary>
    /// 表示需要用户登录才可以使用的特性
    /// 如果不需要处理用户登录，则请指定AllowAnonymousAttribute属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {

        private int RoleValue;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AuthorizationAttribute(int roleValue)
        {
            RoleValue = roleValue;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext == null)
            {
                throw new Exception("此特性只适合于Web应用程序使用！");
            }
            else
            {
                if (filterContext.HttpContext.Session == null)
                {
                    throw new Exception("服务器Session不可用！");
                }
                else if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) &&
                         !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                {
                    if (filterContext.HttpContext.Session["LoginUser"] == null)
                    {
                        filterContext.Result = new RedirectResult("/Home/Login");
                    }
                    else
                    {
                        var loginUser = filterContext.HttpContext.Session["LoginUser"] as User;
                        if ((loginUser.UserRole & RoleValue) == 0)
                        {
                            filterContext.Result = new RedirectResult("/Home/RoleErr");
                        }
                    }
                }


            }
        }
    }
}