using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WritersController : Controller
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            var WriterValues = _writerManager.GetAll();
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _writerManager.AddWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = _writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                _writerManager.UpdateWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}