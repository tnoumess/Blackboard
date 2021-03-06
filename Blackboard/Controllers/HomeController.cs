﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blackboard.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Student,Instructor,Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Instructor")]
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

        [Authorize(Roles = "Student")]
        public ActionResult StudentForm()
        {
            ViewBag.Message = "Student Information Form.";

            return View();
        }

    }
}