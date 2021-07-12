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
    public class WriterPanelMessageController : Controller
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator _messageValidator = new MessageValidator();

        // GET: WriterPanelMessage
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

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}