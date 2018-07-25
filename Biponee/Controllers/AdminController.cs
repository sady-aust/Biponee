using Biponee.BLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biponee.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPage(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
        }
        public ActionResult AddProduct(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
        }
        public ActionResult Orders(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
        }
        public ActionResult Charts(int id)
        {
            AdminC admin = adminManager.getAdminInfo(id);
            return View(admin);
           
        }

        public JsonResult getAdmin(String Email,String Password)
        {
           int idNo = adminManager.isExist(Email, Password);

            if (idNo >0)
            {
                return Json(idNo, JsonRequestBehavior.AllowGet);
            }
            return Json(idNo, JsonRequestBehavior.AllowGet);

        }
    }
}