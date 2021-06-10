using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        private ContactManager _contactManager = new ContactManager(new EfContactDal());

        private ContactValidator _contactValidator = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var ContactValues = _contactManager.GetAll();
            return View(ContactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var ContactValues = _contactManager.GetById(id);
            return View(ContactValues);
        }
    }
}