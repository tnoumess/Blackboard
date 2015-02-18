using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blackboard.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Student,Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Instructor,Administrator")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}