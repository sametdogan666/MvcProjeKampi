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
    public class MessagesController : Controller
    {
        // GET: Messages

        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            return View();
        }
    }
}