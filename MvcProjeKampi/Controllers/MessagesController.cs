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
    public class MessagesController : Controller
    {
        // GET: Messages

        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator _messageValidator = new MessageValidator();
        
        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = _messageManager.GetAllInbox();
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageList = _messageManager.GetAllSendbox();
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

            ValidationResult result = _messageValidator.Validate(message);
            if (result.IsValid)
            {
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
    }
}