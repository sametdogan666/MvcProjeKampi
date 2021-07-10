using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            MvcContext mvcContext = new MvcContext();
            var adminUserInfo = mvcContext.Admins.FirstOrDefault(x =>
                x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (adminUserInfo !=null)
            {
                return RedirectToAction("Index", "AdminCategories");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}