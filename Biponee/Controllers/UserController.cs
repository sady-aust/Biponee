using Biponee.BLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biponee.Controllers
{
    public class UserController : Controller
    {

        ProductManager productManager = new ProductManager();
        SectionManager sectionManager = new SectionManager();
        UserManager userManager = new UserManager();
        CartManager cartManager = new CartManager();
        // GET: User
       /* public ActionResult Index()
        {
            List<ProductC> productList = productManager.GetAllProduct();
            List<SectionC> sections = sectionManager.getAllSections();
            ViewBag.sections = sections;
            return View(productList);
        }*/

        public ActionResult Cart(int userId)
        {
            List<CartC> list = cartManager.getAllItemWithImage(userId);
            return View(list);
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CustmerAccount()
        {
            return View();
        }

        public ActionResult ProductPage(int id)
        {
            ProductC product = productManager.getProductByProductId(id);
            List<SectionC> sections = sectionManager.getAllSections();
            ViewBag.sections = sections;
            return View(product);
        }
      /*  public ActionResult Products(int id, String ProductName, String category, Boolean searchInCategory = false)
        {
            if (ProductName != null)
            {
                List<ProductC> productList = productManager.GetProducts(ProductName);
                List<SectionC> sections = sectionManager.getAllSections();
                ViewBag.sections = sections;
                return View(productList);
            }

            else
            {
                if (!searchInCategory)
                {
                    List<ProductC> productList = productManager.GetAllProductThisSection(id);
                    List<SectionC> sections = sectionManager.getAllSections();
                    ViewBag.sections = sections;
                    return View(productList);
                }
                else
                {
                    List<ProductC> productList = productManager.GetProducts(id, category);
                    List<SectionC> sections = sectionManager.getAllSections();
                    ViewBag.sections = sections;
                    return View(productList);
                }
            }

        }*/
      
        
       /* public JsonResult getAllProduct()
        {
            List<ProductC> list = productManager.GetAllProduct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }*/

        public JsonResult userSignUp(String FirstName,String LastName,String email,String Password)
        {
            UserC user = new UserC(FirstName, LastName, email, Password);
           Boolean res = userManager.insertUserInfo(user);

            if (res)
            {
                UserC loginuser = userManager.getetUser(email, Password);
                return Json(loginuser, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult userLogIn(String Email,String Password)
        {
            UserC res = userManager.getetUser(Email, Password);
         
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        public JsonResult insertCartItem(int ProductId,int Qunaity,int UserID,int Status,String Size)
        {
            CartC myCart = new CartC(ProductId, Qunaity, UserID, Status, Size);
            bool isInserted = cartManager.insertItem(myCart);

            if (isInserted)
            {
                List<CartC> cartList = cartManager.getAllItemWithImage(UserID);
                return Json(cartList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getAllCartItem(int UserID)
        {
            List<CartC> cartList = cartManager.getAllItemWithImage(UserID);
            return Json(cartList, JsonRequestBehavior.AllowGet);
        }

       /* public JsonResult allProduct()
        {
            List<ProductC> productList = productManager.GetAllProduct();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }*/

    }
}