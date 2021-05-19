using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using DataAccess.EntityFramework;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        private WriterManager _writerManager = new WriterManager(new EfWriterDal());
       
        public ActionResult Index()
        {
            var WriterValues = _writerManager.GetAll();
            return View(WriterValues);
        }
    }
}