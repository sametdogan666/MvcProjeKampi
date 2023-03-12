using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework;
using Entities.Concrete;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        MvcContext mvcContext = new MvcContext();

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string p)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = mvcContext.Writers.Where(x=>x.WriterMail == writerMailInfo).Select(y=>y.WriterId).FirstOrDefault();
            var values = _headingManager.GetAllByWriter(writerIdInfo);

            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = mvcContext.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            _headingManager.AddHeading(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetAll()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            var HeadingValue = _headingManager.GetById(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.UpdateHeading(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = _headingManager.GetById(id);
            HeadingValue.HeadingStatus = false;
            _headingManager.DeleteHeading(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page = 1)
        {
            var headings = _headingManager.GetAll().ToPagedList(page,3);
            return View(headings);
        }

    }
}