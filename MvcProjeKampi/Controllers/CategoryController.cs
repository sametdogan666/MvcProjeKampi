using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private CategoryManager categoryManager = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

    }
}