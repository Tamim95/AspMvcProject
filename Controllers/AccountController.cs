using AspMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        //Post
        [HttpPost]
        public ActionResult Login(string btnSubmit,BaseAccount baseAccount) //string txtUserName, string txtPassword
        {
            string LoginMsg = "";
            if (btnSubmit == "Login")
            {
                bool varifyStatus = baseAccount.VarifyLogin();
                if(varifyStatus) 
                {
                    Session["User"] = baseAccount.UserName;
                    LoginMsg = "Login Success.....";
                    return RedirectToAction("Dashboard", "Home");
                   
                }
                else
                {
                    LoginMsg = "Login Failed...";
                }
            }
            else if(btnSubmit=="Forget Password")
                {
                    return RedirectToAction("forget", "Account");

            }
            ViewBag.LoginMsg = LoginMsg;
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string btnSubmit)
        {
            if(btnSubmit=="Forget Password")
            {
                return RedirectToAction("forget", "Account");
            }
            return RedirectToAction("Login","Account");
        }
        public ActionResult forget()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login","Account");
        }
    }
}

/*
 
//Post
        [HttpPost]
        public ActionResult Login(string btnSubmit,BaseAccount baseAccount) //string txtUserName, string txtPassword
        {
            string LoginMsg = "";
            if (btnSubmit == "Login")
            {
                if(baseAccount.UserName=="Protik" && baseAccount.Password== "123456") //if(baseAccount.txtUserName=="Protik" && txtPassword == "123456")
                {
                    Session["User"] = "Protik";
                    LoginMsg = "Login success.........";
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    LoginMsg = "Login Failed...";
                }
            }
            else if(btnSubmit=="Forget Password")
                {
                    return RedirectToAction("forget", "Account");

            }
            ViewBag.LoginMsg = LoginMsg;
            return View();
        }

 */