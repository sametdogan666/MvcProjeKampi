using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages

        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageList = _messageManager.GetAll();
            return View(messageList);
        }
    }
}