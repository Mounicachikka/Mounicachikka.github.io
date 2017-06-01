using SaazApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace SaazApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Signin()
        {
            AdminModel aa = new AdminModel();
            try
            {
                if (Login.HasLogin == false)
                {
                    if (Request.Cookies["Login"] != null)
                    {
                        aa.Loginid = Request.Cookies["Login"].Values["Loginid"];
                        aa.Password = Request.Cookies["Login"].Values["Password"];
                        aa.Rememberme = true;
                    }
                    return View(aa);
                }
                else
                {
                    Login.HasLogin = false;
                    ViewBag.Error = null;
                    return View();
                    //return View("Adminloggedin");
                }
            }
            catch (Exception ex)
            {
            }
            return View("Adminloggedin");
        }
        [HttpPost]
        public ActionResult Signin(AdminModel aa)
        {

            FormsAuthentication.SetAuthCookie(aa.Loginid, aa.Rememberme);
            Session["Loginid"] = aa.Loginid;
            Session["Password"] = aa.Password;
            if (aa.Rememberme)
            {
                HttpCookie cookie = new HttpCookie("Login");
                cookie.Values.Add("Loginid", aa.Loginid);
                cookie.Values.Add("Password", aa.Password);
                cookie.Expires = DateTime.Now.AddDays(15);
                Response.Cookies.Add(cookie);
            }
            ViewBag.Error = null;
            if (aa.Loginid == "admin" && aa.Password == "1234")
            {
                Login.HasLogin = true;
                return RedirectToAction("Homepage", "Role1");
            }
            else
            {
                string ErrorMessage = "";
                string EmployeeId = "";
                MiddleTyre.CheckUser(aa.Loginid, aa.Password, ref ErrorMessage, ref EmployeeId);
                if (ErrorMessage == "Valid User")
                {
                    Login.HasLogin = true;
                    Session["UserId"] = EmployeeId;
                    string EmployeeName = "";
                    MiddleTyre.GetEmployeeName(EmployeeId,ref EmployeeName,ref ErrorMessage);
                    if (ErrorMessage == "")
                    {
                        ViewBag.Error = ErrorMessage;
                    }
                    Session["EmployeeName"]= EmployeeName;
                    return RedirectToAction("Homepage", "Role2");
                }
                else
                {
                    Login.HasLogin = false;
                    ViewBag.Error = ErrorMessage;
                    return View();
                }

            }
        }

        public ActionResult Logout()
        {
            Login.HasLogin = false;
            return View("Adminloggedin");
            //return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult SendEmailView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmailView(sendemail snd)
        {
            MiddleTyre.SendEmailView(snd);
            return View("Adminloggedin");
        }
    }
}
