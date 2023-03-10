 using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());


        public PartialViewResult Index(int id = 0)
        {
            var contentList  = contentManager.GetAllByHeadingId(id); 
            return PartialView(contentList);
        }

        public ActionResult Headings ()
        {
            var headingList = headingManager.GetAll();
            return View(headingList);
        }
    }
}