using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaazApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            ViewBag.Message = "Products";

            return View();
        }
        public ActionResult IP()
        {
            ViewBag.Message = "IP";
            return View();
        }
        public ActionResult ContactUs()
        {
            ViewBag.Message = "Contact Us";
            return View();
        }
    }
}