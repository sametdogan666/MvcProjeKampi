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
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());

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

        public PartialViewResult MessageListMenu(string p)
        {
            var contact = _contactManager.GetAll().Count();
            ViewBag.contact = contact;

            var sendMail = _messageManager.GetAllSendbox(p).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = _messageManager.GetAllInbox(p).Count();
            ViewBag.receiverMail = receiverMail;

            //var draftMail = _messageManager.GetAllSendbox().Where(m => m.IsDraft == true).Count();
            //ViewBag.draftMail = draftMail;

            //var readMessage = _messageManager.GetAllInbox().Where(m => m.IsRead == true).Count();
            //ViewBag.readMessage = readMessage;

            //var unreadMessage = _messageManager.GetAllRead().Count();
            //ViewBag.unreadMessage = unreadMessage;

            return PartialView();
        }
    }
}