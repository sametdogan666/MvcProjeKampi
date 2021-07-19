using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {

        private ContentManager _contentManager = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            MvcContext mvcContext = new MvcContext();
            p = (string) Session["WriterMail"];
            var writerIdInfo = mvcContext.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId)
                .FirstOrDefault();
            var contentValues = _contentManager.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }
    }
}