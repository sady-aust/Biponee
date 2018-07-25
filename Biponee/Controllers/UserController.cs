using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biponee.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CustmerAccount()
        {
            return View();
        }

        public ActionResult ProductPage()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }


    }
}