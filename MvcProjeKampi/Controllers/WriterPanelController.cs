using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(int id)
        {
            id = 4;
            var values = _headingManager.GetAllByWriter(id);
            return View(values);
        }
    }
}