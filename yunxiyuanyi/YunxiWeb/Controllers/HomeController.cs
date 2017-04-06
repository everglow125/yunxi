using Common;
using Entity.LogicModel;
using ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace YunxiWeb.Controllers
{
    public class HomeController : Controller
    {
        public IUserBll UserSvc { get; set; }
        public HomeController(IUserBll userBll)
        {
            UserSvc = userBll;
        }

        [Authorization(31)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            var user = UserSvc.QueryLoginUser(model.LoginName);
            bool loginSuccess = user != null && model.LoginPwd.ToMD5_32() == user.LoginPwd.Trim();
            if (loginSuccess)
                Session.Add("LoginUser", user);

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            User model = new Entity.LogicModel.User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            var result = UserSvc.Insert(model);
            return View();
        }

        public ActionResult RoleErr()
        {
            return View();
        }

    }
}