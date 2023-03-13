using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator _messageValidator = new MessageValidator();

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var messageList = _messageManager.GetAllInbox(writerMailInfo);

            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var messageList = _messageManager.GetAllSendbox(writerMailInfo);

            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = _messageManager.GetById(id);

            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = _messageManager.GetById(id);

            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            ValidationResult result = _messageValidator.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = writerMailInfo;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageManager.AddMessage(message);

                return RedirectToAction("SendBox");
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

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}