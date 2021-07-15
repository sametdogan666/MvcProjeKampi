using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {

        private ContentManager _contentManager = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            var contentValues = _contentManager.GetAllByWriter();
            return View(contentValues);
        }
    }
}