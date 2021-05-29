using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using global::Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.AddCategory(category);
                return RedirectToAction("GetAll");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
    
}