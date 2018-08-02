using Biponee.BLL;
using Biponee.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Biponee.Controllers
{
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager();
        SectionManager sectionManager = new SectionManager();
        ProductManager productManager = new ProductManager();

      

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminPage()
        {

            int id = Convert.ToInt32(Session["adminId"]);
            return View();
        }
        public ActionResult AddProduct()
        {
           
            List<SectionC> sections = sectionManager.getAllSections();
            Session["sectionInfo"] = sections;
            List<ProductC> myProducts = productManager.getAllProduct();
            return View(new AdminSectionC(sections,myProducts));
        }
        [HttpPost]
        public ActionResult AddProduct(ProductC product)
        {
            WebImage photo = null;
            var newFileName = "";
            var imagePath = "";
            photo = WebImage.GetImageFromRequest();
            if (product.ProductName != null && product.SectionId > 0 && product.ProductCode != null && product.Price != null && photo != null)
            {
                if (!productManager.isThisCodeAlreadyExist(product.ProductCode))
                {
                    photo.FileName = product.ProductCode + "img";
                    newFileName = photo.FileName;
                  

                    imagePath = @"Style/ProductImage/" + product.SectionId + @"/" + newFileName;

                    photo.Save(@"~/" + imagePath);
                    product.ImageLink = imagePath;

                    Boolean res = productManager.insertProduct(product);
                    if (res)
                    {
                       ViewBag.insertResult = "1";

                        List<ProductC> myProducts = productManager.getAllProduct();
                        return View(new AdminSectionC((AdminC)Session["adminIndo"],(List<SectionC>) Session["sectionInfo"], myProducts));
                    }
                    else
                    {
                        List<ProductC> myProducts = productManager.getAllProduct();
                        ViewBag.insertResult = "0";
                        return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], myProducts));
                    }
                }
                else
                {
                   ViewBag.insertResult = "2";
                    List<ProductC> myProducts = productManager.getAllProduct();
                    return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], myProducts));
                }
            }
            else
            {
               ViewBag.insertResult = "3";
                List<ProductC> myProducts = productManager.getAllProduct();
                return View(new AdminSectionC((AdminC)Session["adminIndo"], (List<SectionC>)Session["sectionInfo"], myProducts));
            }
           

            
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
                AdminC loggingAdmin = adminManager.getAdminInfo(idNo);
                return Json(loggingAdmin, JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);

        }

        public JsonResult getAllProduct(int SectionId)
        {
            List<ProductC> list = productManager.getAllProductThisSection(SectionId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult  getProductOfThisCode(int SectionId, String Code)
        {
            List<ProductC> list = productManager.getProduct(SectionId, Code);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}