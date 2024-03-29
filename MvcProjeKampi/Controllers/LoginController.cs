﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Web.Security;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private WriterLoginManager _loginManager = new WriterLoginManager(new EfWriterDal());

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
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategories");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //MvcContext mvcContext = new MvcContext();
            //var writerUserInfo = mvcContext.Writers.FirstOrDefault(x =>
            //    x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writerUserInfo = _loginManager.GetWriter(writer.WriterMail, writer.WriterPassword);

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}