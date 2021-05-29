using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class HeadingsController : Controller
    {
        // GET: Headings
        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = _headingManager.GetAll();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            
            List<SelectListItem> valueWriter = (from x in _writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.AddHeading(heading);
            return RedirectToAction("Index");
        }
    }
}