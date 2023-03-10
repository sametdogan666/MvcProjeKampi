using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {

        private ContentManager _contentManager = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            MvcContext mvcContext = new MvcContext();
            p = (string)Session["WriterMail"];
            var writerIdInfo = mvcContext.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId)
                .FirstOrDefault();
            var contentValues = _contentManager.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }


        public ActionResult AddContent(int id)
        {
            ViewBag.headingId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            MvcContext mvcContext = new MvcContext();
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = mvcContext.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId)
                .FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;

            _contentManager.AddContent(content);

            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();  
        }
    }
}