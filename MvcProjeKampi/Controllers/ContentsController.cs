using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class ContentsController : Controller
    {
        // GET: Contents

        private ContentManager _contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = _contentManager.GetAllByHeadingId(id);
            return View(contentValues);
        }
    }
}