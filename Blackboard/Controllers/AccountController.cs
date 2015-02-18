using Blackboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Blackboard.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] Login logindata, String ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(logindata.Username, logindata.Password))
                {

                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else {
                    ModelState.AddModelError("", "Sorry Invalid Email or Password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

         [HttpGet]
         [Authorize(Roles = "Administrator")]
        public ActionResult Register()
        {
           
                return View();
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Register([Bind(Include = "Username,Password,Role")] Register r, String Role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(r.Username, r.Password);
                    Roles.AddUserToRole(r.Username, Role);
                    return RedirectToAction("Login", "Account");
                }
                catch (MembershipCreateUserException e)
                {

                   ModelState.AddModelError("","Sorry this Email already exists");
                   return View();               
                
                }
            }
            else
            {
               
                return View();
            
            }
        }
        public ActionResult Logout() {

            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}