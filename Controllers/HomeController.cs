using AspMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session["User"] != null)
            {
                List<BaseEquipment> plstData = BaseEquipment.ListEquipmentData();

                ViewBag.plstData = plstData;
                ViewBag.txtName = "";
                return View();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }
        [HttpPost]
        public ActionResult Dashboard(FormCollection frm,string btnSubmit, string txtPassword, string txtUserName)
        {
            List<BaseEquipment> plstData = BaseEquipment.ListEquipmentData();

            ViewBag.plstData = plstData;
            ViewBag.txtName = "";
            if (btnSubmit == "Search")
            {
                ViewBag.txtName = frm["txtName"].ToString();
            }
            
            return View();
        }

    }
}
/*
 * List<BaseEquipment> plstData = BaseEquipment.ListEquipmentData();
            ViewBag.plstData = plstData;
            ViewBag.txtName = "";
            if (btnSubmit=="Search")
            {
                ViewBag.txtName = frm["txtName"].ToString();
            }
           
            return View();
 */