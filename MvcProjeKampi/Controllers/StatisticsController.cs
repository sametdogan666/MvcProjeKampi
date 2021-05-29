using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Concrete.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {

        MvcContext _mvcContext = new MvcContext();
        // GET: Statistics
        public ActionResult Index()
        {
            var totalCategory = _mvcContext.Categories.Count().ToString();
            ViewBag.v1 = totalCategory;

            var softwareCategory = _mvcContext.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.v2 = softwareCategory;

            var authorsContainingA = _mvcContext.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.v3 = authorsContainingA;

            var categoryWithTheMostTitles = _mvcContext.Categories.Where(x => x.CategoryId == _mvcContext.Headings.GroupBy(y => y.CategoryId)
                .OrderByDescending(z => z.Count()).Select(t => t.Key).FirstOrDefault()).Select(k => k.CategoryName).FirstOrDefault();
            ViewBag.v4 = categoryWithTheMostTitles;

            var trueMinusFalse = _mvcContext.Categories.Count(x => x.CategoryStatus == true) - _mvcContext.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.v5 = trueMinusFalse;

            return View();
            
        }
    }
}